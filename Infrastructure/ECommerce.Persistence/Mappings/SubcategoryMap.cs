using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Mappings
{
    public class SubcategoryMap : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            var subcategory1 = new Subcategory
            {
                Id = Guid.Parse("5c324b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                NameTR = "Tablet",
                NameEN = "Tablet",
                CreatedDate = DateTime.Now,
                CategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                IsDeleted = false,
            };
            var subcategory2 = new Subcategory
            {
                Id = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                NameTR = "Dizüstü",
                NameEN = "Laptop",
                CreatedDate = DateTime.Now,
                CategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                IsDeleted = false,
            };
            var subcategory3 = new Subcategory
            {
                Id = Guid.Parse("3c684b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                NameTR = "Masaüstü",
                NameEN = "Desktop",
                CreatedDate = DateTime.Now,
                CategoryId = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                IsDeleted = false,
            };
            var subcategory4 = new Subcategory
            {
                Id = Guid.Parse("2a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                NameTR = "Tavan",
                NameEN = "Ceiling",
                CreatedDate = DateTime.Now,
                CategoryId = Guid.Parse("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                IsDeleted = false,
            };
            var subcategory5 = new Subcategory
            {
                Id = Guid.Parse("4a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                NameTR = "Lambader",
                NameEN = "Floor Lamp",
                CategoryId = Guid.Parse("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(new Subcategory[] { subcategory1, subcategory2, subcategory3, subcategory4, subcategory5 });
        }
    }
}
