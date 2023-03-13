using ECommerce.Application.Interfaces.Context;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Context;
using ECommerce.Persistence.Repositories;
using ECommerce.Persistence.Services;
using ECommerce.Persistence.UnitOfWorks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(
            //    opt => opt.UseNpgsql(
            //        configuration.GetConnectionString("PostgreConnection"),
            //            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<AppDbContext>(
                opt => opt.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = true;
            })
                .AddRoleManager<RoleManager<Role>>()
                        .AddEntityFrameworkStores<AppDbContext>()
                            .AddDefaultTokenProviders();


        }
        public static void AddToModelErrorIdentity(this IdentityResult identityResult, ModelStateDictionary state)
        {
            foreach (var error in identityResult.Errors)
            {
                state.AddModelError("", error.Description);
            }
        }
        public static void AddToModelError(this ValidationResult result, ModelStateDictionary state)
        {
            foreach (var error in result.Errors)
            {
                state.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
