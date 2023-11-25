global using AniWorldReminder_Webpanel.Enums;
global using AniWorldReminder_Webpanel.Classes;
global using AniWorldReminder_Webpanel.Services;
global using AniWorldReminder_Webpanel.Models;
global using AniWorldReminder_Webpanel.Interfaces;
global using Newtonsoft.Json;
using Havit.Blazor.Components.Web;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHxServices();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

builder.Services.AddScoped(_ =>
{
    return new HttpClient() { BaseAddress = new Uri("https://localhost:5001/") };
    // BaseAddress = new Uri("https://aniworldapi.lucaweidmann.de"); };
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
