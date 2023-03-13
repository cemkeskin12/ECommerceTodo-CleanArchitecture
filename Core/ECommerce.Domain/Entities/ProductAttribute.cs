namespace ECommerce.Domain.Entities
{
    public class ProductAttribute
    {
        public Guid ProductId { get; set; }
        public Guid AttributeId { get; set; }
        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
    }
}
