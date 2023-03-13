using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Mappings
{
    public class SubategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var category1 = new Category
            {
                Id = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                NameTR = "Bilgisayar",
                NameEN = "Computer",
                CreatedDate = DateTime.Now,
                IsDeleted= false,
            };
            var category2 = new Category
            {
                Id = Guid.Parse("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                NameTR = "Lamba",
                NameEN = "Lamp",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };


            builder.HasData(new Category[] {category1,category2});
        }
    }
}
