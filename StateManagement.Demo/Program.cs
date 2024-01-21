using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluxor(opts =>
{
    opts.ScanAssemblies(typeof(Program).Assembly);
    opts.UseReduxDevTools();
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IConversationService, ConversationService>();

await builder.Build().RunAsync();