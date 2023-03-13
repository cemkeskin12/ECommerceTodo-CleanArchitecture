using ECommerce.Application;
using ECommerce.Infrastructure;
using ECommerce.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var token = string.Empty;
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7237/");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
});
builder.Services.AddScoped(_ =>
{
    var clientFactory = _.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.Use(async (context, next) =>
{
    token = context.Session.GetString("Token");
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
app.MapDefaultControllerRoute();

app.Run();
