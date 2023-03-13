using Bogus;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var fake = new Faker("tr");

            builder.HasData(new Product[] {
            new Product()
            {
                Id = Guid.Parse("5266BAC2-053F-4ACA-8FBA-23193D018422"),
                Name = fake.Commerce.ProductName(),
                Price = decimal.Parse(fake.Commerce.Price(50, 100000)),
                BrandId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                SubcategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                Description = fake.Commerce.ProductDescription(),
                CreatedDate = fake.Date.Between(DateTime.Now.AddDays(-10), DateTime.Now),
                IsDeleted = fake.Random.Bool(),
            },
            new Product()
            {
                Id = Guid.Parse("6266BAC2-053F-4ACA-8FBA-23193D018422"),
                Name = fake.Commerce.ProductName(),
                Price = decimal.Parse(fake.Commerce.Price(50, 100000)),
                BrandId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                SubcategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                Description = fake.Commerce.ProductDescription(),
                CreatedDate = fake.Date.Between(DateTime.Now.AddDays(-10), DateTime.Now),
                IsDeleted = fake.Random.Bool(),
            },
            new Product()
            {
                Id = Guid.Parse("7266BAC2-053F-4ACA-8FBA-23193D018422"),
                Name = fake.Commerce.ProductName(),
                Price = decimal.Parse(fake.Commerce.Price(50, 100000)),
                BrandId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                SubcategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                Description = fake.Commerce.ProductDescription(),
                CreatedDate = fake.Date.Between(DateTime.Now.AddDays(-10), DateTime.Now),
                IsDeleted = fake.Random.Bool(),
            },
            new Product()
            {
                Id = Guid.Parse("8266BAC2-053F-4ACA-8FBA-23193D018422"),
                Name = fake.Commerce.ProductName(),
                Price = decimal.Parse(fake.Commerce.Price(50, 100000)),
                BrandId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                SubcategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                Description = fake.Commerce.ProductDescription(),
                CreatedDate = fake.Date.Between(DateTime.Now.AddDays(-10), DateTime.Now),
                IsDeleted = fake.Random.Bool(),
            },
        });
        }
    }
}
