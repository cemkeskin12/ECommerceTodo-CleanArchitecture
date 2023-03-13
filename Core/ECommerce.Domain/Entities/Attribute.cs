using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Attribute : EntityBase,IEntityBase
    {
        public string? NameTR { get; set; }
        public string? NameEN { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<AttributeValue> AttributeValues { get; set; }

    }
}
