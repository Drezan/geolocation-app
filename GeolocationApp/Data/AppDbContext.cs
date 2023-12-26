using GeolocationApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace GeolocationApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>().Property(u => u.UserId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<User>().HasIndex(u => u.UserId).IncludeProperties(u => u.Username);

            //Location
            modelBuilder.Entity<Location>().Property(l => l.LocationId).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Location>().HasIndex(l => l.LocationId);
        }
    }
}
