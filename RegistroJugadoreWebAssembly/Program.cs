using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegistroJugadoreWebAssembly;
using RegistroJugadoreWebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/")
});

builder.Services.AddScoped<IPartidasApiservices, PartidasApiService>();
builder.Services.AddScoped<IMovimientosApiService, MovimientosApiService>();

await builder.Build().RunAsync();
