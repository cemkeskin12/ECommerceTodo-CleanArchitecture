using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Brand : EntityBase, IEntityBase
    {
        public Brand()
        {

        }
        public Brand(string name,string picture)
        {
            Name = name;
            Picture = picture;
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public string? Picture { get; set; }
    }
}