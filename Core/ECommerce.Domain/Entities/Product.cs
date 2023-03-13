using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            Images = new HashSet<Image>();
            Baskets = new HashSet<Basket>();
            OrderProducts = new HashSet<OrderProduct>();
        }
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Guid SubcategoryId { get; set; }


        public Subcategory Subcategory { get; set; }
        public Brand Brand { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Basket> Baskets { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
