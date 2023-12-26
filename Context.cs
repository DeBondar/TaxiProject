using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiProject.models;

namespace TaxiProject
{
    public class Context : DbContext
    {
        public DbSet<Driver> drivers { get; set; } = null!;

        public DbSet<Taxi> taxis { get; set; } = null!;
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) 
        { 
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        //Fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasKey(x => x.LicenseNumber);
            modelBuilder.Entity<Driver>().Property(d => d.Name).HasDefaultValue("No name").HasMaxLength(100);
            modelBuilder.Entity<Driver>().HasCheckConstraint("LicenseNumber", "LicenseNumber > 0");

            modelBuilder.Entity<Driver>().HasData
                (
                    new Driver { LicenseNumber = 1, Name = "James Clear" },
                    new Driver { LicenseNumber = 2, Name = "Lucy Monte" },
                    new Driver { LicenseNumber = 3, Name = "Bob Whalley" },
                    new Driver { LicenseNumber = 4, Name = "Jack Rassel" }
                );

            modelBuilder.Entity<Taxi>().HasData
                (
                    new Taxi { RegistrationNumber = "KA2211НР", TaxiId = 1, Brand = "Renault", Model = "Logan" },
                    new Taxi { RegistrationNumber = "KA3258СК", TaxiId = 2, Brand = "Renault", Model = "Megane" },
                    new Taxi { RegistrationNumber = "KA0258МН", TaxiId = 3, Brand = "Chevrolet", Model = "Cruze" },
                    new Taxi { RegistrationNumber = "АІ9135НН", TaxiId = 4, Brand = "Nissan", Model = "X-trail" }
                    
                );
        }



    }
}
