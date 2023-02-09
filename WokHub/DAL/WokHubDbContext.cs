using Microsoft.EntityFrameworkCore;
using WokHub.DAL.Models;

namespace WokHub.DAL
{
    public class WokHubDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public WokHubDbContext(DbContextOptions<WokHubDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(e => e.Id);
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = Guid.NewGuid(),
                Email = "aboba@gmail.com",
                Password = "aboba123"
            });
        }
    }
}
