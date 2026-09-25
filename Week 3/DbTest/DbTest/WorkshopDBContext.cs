using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbTest

{
    internal class WorkshopDBContext : DbContext
    {
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    
        public WorkshopDBContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("workshop.db").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>(registration => registration.HasOne(r => r.Workshop).WithMany(W => W.Registrations).HasForeignKey(r => r.WorkshopId).OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Workshop>().HasData(
new Workshop
{
   WorkshopId = 1,
   Title = "Halado LINQ",
   Topic = "C#",
   Capacity = 12,
   StartsAt = new DateTime(2026, 10, 6, 14, 0, 0)
},
new Workshop
{
   WorkshopId = 2,
   Title = "EF Core Code First",
   Topic = "Adatbazis",
   Capacity = 10,
   StartsAt = new DateTime(2026, 10, 13, 14, 0, 0)
},
new Workshop
{
   WorkshopId = 3,Registrations 
   Title = "Unit teszteles",
   Topic = "Minosegbiztositas",
   Capacity = 8,
   StartsAt = new DateTime(2026, 10, 20, 14, 0, 0)
},
new Workshop
{
   WorkshopId = 4,
   Title = "Git workflow",
   Topic = "Fejlesztesi eszkozok",
   Capacity = 15,
   StartsAt = new DateTime(2026, 10, 27, 14, 0, 0)
});

            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    StudentName = "Anna",
                    Score = 92,
                    RegisteredAt = new DateTime(2026, 9, 1),
                    WorkshopId = 1
                },
                new Registration
                {
                    RegistrationId = 2,
                    StudentName = "Bela",
                    Score = 78,
                    RegisteredAt = new DateTime(2026, 9, 2),
                    WorkshopId = 1
                },
                new Registration
                {
                    RegistrationId = 3,
                    StudentName = "Csilla",
                    Score = 88,
                    RegisteredAt = new DateTime(2026, 9, 3),
                    WorkshopId = 2
                },
                new Registration
                {
                    RegistrationId = 4,
                    StudentName = "David",
                    Score = 65,
                    RegisteredAt = new DateTime(2026, 9, 4),
                    WorkshopId = 2
                },
                new Registration
                {
                    RegistrationId = 5,
                    StudentName = "Eszter",
                    Score = 95,
                    RegisteredAt = new DateTime(2026, 9, 5),
                    WorkshopId = 3
                });
        }


    }
}
