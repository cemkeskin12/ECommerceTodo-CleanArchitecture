namespace ECommerce.Web.Routes
{
    public static class ProductEndpoints
    {
        public static string GetAllProducts = "api/Product/GetAllProducts";
        public static string GetProduct(string productId)
        {
            return $"api/Product/GetProduct/{productId}";
        }
    }
}
