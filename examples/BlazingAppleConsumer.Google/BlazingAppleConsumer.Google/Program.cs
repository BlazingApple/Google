using BlazingApple.Google.Services;
using BlazingApple.Google.Services.Calendars;
using BlazingAppleConsumer.Google;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazingAppleGoogle(builder.Configuration);
builder.Services.AddScoped<CalendarRetrievalService>();
await builder.Build().RunAsync();
