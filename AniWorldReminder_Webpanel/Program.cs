global using AniWorldReminder_Webpanel.Enums;
global using AniWorldReminder_Webpanel.Classes;
global using AniWorldReminder_Webpanel.Services;
global using AniWorldReminder_Webpanel.Models;
global using AniWorldReminder_Webpanel.Interfaces;
global using Newtonsoft.Json;
using Havit.Blazor.Components.Web;           
using Havit.Blazor.Components.Web.Bootstrap; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHxServices();

builder.Services.AddHttpClient<IApiService, ApiService>("apiclient", _ =>
{
    _.BaseAddress = new Uri("https://localhost:5001/");
    // _.BaseAddress = new Uri("https://aniworldapi.lucaweidmann.de");
});

builder.Services.AddSingleton<IApiService, ApiService>();

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
