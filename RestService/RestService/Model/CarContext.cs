using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Model
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> CarOption) : base(CarOption)
        {

        }

        public DbSet<Cars> cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>().HasData(
                new Cars
                {
                    Id = 1,
                    MarkName = "Mercedes",
                    ModelName = "G___55",
                    Year = 2016
                },

                new Cars
                {
                    Id = 2,
                    MarkName = "Nissan",
                    ModelName = "X-terra",
                    Year = 2003
                },

                new Cars
                {
                    Id = 3,
                    MarkName = "Toyota",
                    ModelName = "Land Crouiser 200",
                    Year = 2018
                },

                new Cars
                {
                    Id = 4,
                    MarkName = "Dayhatcu",
                    ModelName = "Bqumba",
                    Year = 1985
                }
            );
        }
    }
}
