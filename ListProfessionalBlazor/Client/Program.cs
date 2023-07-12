global using ListProfessionalBlazor.Client.Services.ListProfessionalService;
global using ListProfessionalBlazor.Shared;
using ListProfessionalBlazor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IListProfessionalService, ListProfessionalService>();

await builder.Build().RunAsync();
