global using AniWorldReminder_Webpanel.Enums;
global using AniWorldReminder_Webpanel.Classes;
global using AniWorldReminder_Webpanel.Services;
global using AniWorldReminder_Webpanel.Models;
global using AniWorldReminder_Webpanel.Interfaces;
global using Newtonsoft.Json;
global using BlazorDownloadFile;
using Havit.Blazor.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHsts(_ =>
{
    _.Preload = true;
    _.IncludeSubDomains = true;
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHxServices();
builder.Services.AddHxMessenger();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddBlazorDownloadFile(ServiceLifetime.Scoped);

SettingsModel? settings = SettingsHelper.ReadSettings<SettingsModel>();

if(settings is null)
{
    Console.WriteLine("Couldn't read or find Settings file!. Shutting down!");
    return;
}

builder.Services.AddScoped(_ =>
{
   return new HttpClient() { BaseAddress = new Uri(settings.ApiUrl) };
});

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
