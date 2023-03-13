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
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            var brand = new Brand
            {
                Id = Guid.Parse("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                Name = "Monster",
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            };
            builder.HasData(brand);

            
        }
    }
}
