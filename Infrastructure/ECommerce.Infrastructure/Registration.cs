using ECommerce.Application.Interfaces.Mails;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Interfaces.Storage;
using ECommerce.Application.Interfaces.Storage.Azure;
using ECommerce.Application.Interfaces.Tokens;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.Services.Mails;
using ECommerce.Infrastructure.Services.RabbitMQ;
using ECommerce.Infrastructure.Services.Storage;
using ECommerce.Infrastructure.Services.Storage.Azure;
using ECommerce.Infrastructure.Services.Tokens;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace ECommerce.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IAzureStorage, AzureStorage>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Token:Audience"],
                    ClockSkew = TimeSpan.Zero
                    
                };
            });

        }
        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage,T>();
        }
    }
}
