using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WasmUI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<IAppKeys, AppKeys>();
builder.Services.AddSingleton<IDisplay, Display>();
builder.Services.AddSharedUI(SharedUIPlatform.BlazorWASM);

await builder.Build().RunAsync();
