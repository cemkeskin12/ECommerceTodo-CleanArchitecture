using ECommerce.Application.Interfaces.Context;
using ECommerce.Domain.Config;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>, IAppDbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Success> Successes { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

}
