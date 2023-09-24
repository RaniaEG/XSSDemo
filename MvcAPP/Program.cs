using Microsoft.AspNetCore;
using Microsoft.Extensions.Logging;
using MvcAPP;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Removing Server Header
//Sometimes, headers could provide some information that is better to hide.
//To disable the Server header from Kestrel, you need to set AddServerHeader to false.
//Use UseKestrel() if your ASP.NET Core version is lower than 2.2 and ConfigureKestrel() if not.

WebHost.CreateDefaultBuilder(args)
.ConfigureKestrel(c => c.AddServerHeader = false)
.UseStartup<Startup>()
.Build();

app.Run();
