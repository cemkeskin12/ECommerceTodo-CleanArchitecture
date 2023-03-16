using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.ElasticSearch
{
    public static class Registration
    {
        public static void AddElasticSearch(this IServiceCollection services)
        {
            services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        }
    }
}
