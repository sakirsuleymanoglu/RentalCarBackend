using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RentalCar.Entities.Concrete;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class RentalCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RCE6ARO\SQLEXPRESS; Initial Catalog=RentalCar; Integrated Security=True;");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
