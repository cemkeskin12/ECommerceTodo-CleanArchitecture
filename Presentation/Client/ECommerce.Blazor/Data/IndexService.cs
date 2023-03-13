using ECommerce.Domain.Entities;

namespace ECommerce.Blazor.Data
{
    public class IndexService
    {
        private readonly HttpClient httpClient;

        public IndexService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //public async Task<List<Product>> GetProductsAsync()
        //{
        //    var products = await httpClient.GetFromJsonAsync<List<Product>>("api/Home/Index");
        //    return products;
        //}
    }
}
