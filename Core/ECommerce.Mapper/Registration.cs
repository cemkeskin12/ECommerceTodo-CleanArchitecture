using ECommerce.Application.Interfaces.AutoMappers;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
