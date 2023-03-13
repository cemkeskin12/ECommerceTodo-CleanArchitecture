using ECommerce.Application.Beheviors;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Application.Rules;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Globalization;
using System.Reflection;

namespace ECommerce.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services,IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            services.AddMediatR(assembly);

            services.AddTransient<ExceptionMiddleware>();

            services.AddControllersWithViews();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseRules));

            services.AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssemblyContaining<RegisterCommandValidator>();
                fv.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                fv.AutomaticValidationEnabled = false;
            });

        }
        public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddTransient(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }
    }
}
