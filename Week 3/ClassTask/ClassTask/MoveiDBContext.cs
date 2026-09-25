using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    internal class MoveiDBContext : DbContext
    {
        public DbSet<Director> Director { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Actor> Actor { get; set; }


        public MoveiDBContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("moveis.db").UseLazyLoadingProxies();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasOne<Director>().WithMany().HasForeignKey("DirectorId");
            modelBuilder.Entity<Role>().HasOne<Movie>().WithMany().HasForeignKey("MovieId");
            modelBuilder.Entity<Director>().HasMany<Movie>().WithOne().HasForeignKey("DirectorId");
            modelBuilder.Entity<Actor>().HasMany<Role>().WithOne().HasForeignKey("ActorId");

            modelBuilder.Entity<Director>().HasData(
                );
        }

    }
}
