using System.Globalization;
using TIN.Core;
using TIN.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices();

builder.Services.AddDataServices(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var cultures = new[] { "en", "ru" };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new("en"),
    SupportedCultures = cultures.Select(c => new CultureInfo(c)).ToList(),
    SupportedUICultures = cultures.Select(c => new CultureInfo(c)).ToList()
});

await app.RunAsync();