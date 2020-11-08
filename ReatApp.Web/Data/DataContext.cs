using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReatApp.Web.Data.Entities;
using RestApp.Common.Entities;

namespace ReatApp.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantImage> RestaurantImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
              .HasIndex(t => t.Name)
              .IsUnique();

        }
    }

}
