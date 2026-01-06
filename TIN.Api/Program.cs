using System.Globalization;
using System.Security.Claims;
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

builder.Services.AddCors(corsBuilder =>
{
    corsBuilder.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .WithOrigins(builder.Configuration.GetConnectionString("Frontend")!)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

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
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role,
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy =>
        policy.RequireRole("Administrator"))
    .AddPolicy("LoggedIn", policy => 
        policy.RequireRole("Administrator", "Customer"));

var app = builder.Build();

app.UseRouting();

app.UseCors();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();