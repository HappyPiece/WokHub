using Microsoft.EntityFrameworkCore;
using WokHub.DAL.Models;

namespace WokHub.DAL
{
    public class WokHubDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public WokHubDbContext(DbContextOptions<WokHubDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Email = "aboba@gmail.com",
                Password = "aboba123"
            });

            modelBuilder.Entity<User>().HasMany(p => p.Orders).WithOne(p => p.User);
            modelBuilder.Entity<User>().HasMany(p => p.CartContents).WithOne(p => p.User);

            modelBuilder.Entity<Order>().HasMany(p => p.Dishes).WithOne(p => p.Order);

            modelBuilder.Entity<DishPile>().HasNoKey();
        }
    }
}
