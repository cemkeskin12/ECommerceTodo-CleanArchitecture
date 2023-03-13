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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role[]{ new Role()
            {
                Id = Guid.NewGuid(),
                Name= "User",
                NormalizedName= "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }});
        }
    }
}
