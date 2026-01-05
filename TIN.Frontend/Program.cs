using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TIN.Frontend;
using TIN.Frontend.Api;
using TIN.Frontend.Auth;
using TIN.Frontend.Cart;
using TIN.Frontend.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Typed http client
builder.Services.AddHttpClient<IApiFetcher, ApiFetcher>(client =>
    {
        client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("Api")!); 
    })
    .AddHttpMessageHandler<JwtHandler>()
    .AddStandardResilienceHandler();

// Auth
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();
builder.Services.AddScoped<JwtHandler>();

// Api
builder.Services.AddScoped<IProductFetcher, ProductFetcher>();
builder.Services.AddScoped<ILocalizationFetcher, LocalizationFetcher>();
builder.Services.AddScoped<IOrderFetcher, OrderFetcher>();
builder.Services.AddScoped<ISpecFetcher, SpecFetcher>();
builder.Services.AddScoped<IUserFetcher, UserFetcher>();

builder.Services.AddScoped<ICartService, CartService>();

// Binding Api endpoints configuration to an IOptions instance
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("Api"));

await builder.Build().RunAsync();