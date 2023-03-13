using ECommerce.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient("WebApiClient",client =>
{
    client.BaseAddress = new Uri("https://localhost:7237/");
});
builder.Services.AddScoped(_ =>
{
    var clientFactory = _.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});
builder.Services.AddTransient<IndexService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapFallbackToAreaPage("~/admin/{*clientroutes:nonfile}", "/_AdminHost", "Admin");

app.Run();
