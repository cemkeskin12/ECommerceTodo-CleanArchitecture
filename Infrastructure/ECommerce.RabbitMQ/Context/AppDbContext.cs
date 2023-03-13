//using ECommerce.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace ECommerce.RabbitMQ.Context
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }
//        public DbSet<User> Users{ get; set; }


//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server=.;Database=ECommerceTodoDb;Trusted_Connection=true;TrustServerCertificate=True;");
//        }


//    }
//}
