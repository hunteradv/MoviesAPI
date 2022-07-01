using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(address => address.MovieTheater)
                .WithOne(movieTheater => movieTheater.Address)
                .HasForeignKey<MovieTheater>(mt => mt.AddressId);

            modelBuilder.Entity<MovieTheater>()
                .HasOne(movieTheater => movieTheater.Manager)
                .WithMany(manager => manager.MovieTheaters)
                .HasForeignKey(movieTheater => movieTheater.ManagerId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
