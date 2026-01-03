using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using TIN_PRO.Middlewares;
using TIN_PRO.Options;
using TIN.Core;
using TIN.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

builder.Services.AddExceptionHandler<StoreExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddOpenApi();

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt")
);

// Tin.Core
builder.Services.AddCoreServices();

// Tin.Data
builder.Services.AddDataServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

var jwtOptions = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtOptions>()!;

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var cultures = new[] { "en", "pl" };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new("en"),
    SupportedCultures = cultures.Select(c => new CultureInfo(c)).ToList(),
    SupportedUICultures = cultures.Select(c => new CultureInfo(c)).ToList()
});

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

app.UseExceptionHandler();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

await app.RunAsync();