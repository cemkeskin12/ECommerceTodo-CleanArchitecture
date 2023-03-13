using ECommerce.Application;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Services.Storage.Azure;
using ECommerce.Mapper;
using ECommerce.Persistence;
using NToastNotify;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCustomMapper();

builder.Services.AddStorage<AzureStorage>();
builder.Services.AddSession(opt => { opt.IdleTimeout = TimeSpan.FromMinutes(5); });
builder.Host.UseSerilog((ctx, lc) 
    => lc.ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddMvcCore().AddNToastNotifyToastr(new ToastrOptions()
{
    PositionClass = ToastPositions.TopRight,
    TimeOut = 3000,
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.LogoutPath = new PathString("/Account/Logout");
    options.Cookie = new CookieBuilder
    {
        Name = "Customer",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest // Always
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSerilogRequestLogging();
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
app.MapDefaultControllerRoute();

app.Run();
