using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Domain.Entities.Attribute> Attributes { get; set; }
        DbSet<ProductAttribute> ProductAttributes { get; set; }
        DbSet<AttributeValue> AttributeValues { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Rating> Ratings { get; set; }
    }
}
