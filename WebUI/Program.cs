using Microsoft.AspNetCore.Authentication.Cookies;
using RiseX.Shared.Utilities.Services;
using RiseX.WebUI;
using RiseX.WebUI.BackgroundServices;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/login";
        options.LogoutPath = "/auth/logout";
        options.Cookie.Name = "risex.auth";
        options.ReturnUrlParameter = "returnUrl";
        options.ExpireTimeSpan=TimeSpan.FromDays(1);
    });

builder.Services.ConfigureServices(builder.Configuration);



builder.Services.AddHostedService<CryptoWorker>();

builder.Host.UseSerilog();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();