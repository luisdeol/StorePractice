using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manufacturers_Test.Models
{
        public class StoreContext : DbContext
        {
            public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
            public DbSet<Manufacturer> Manufacturers { get; set; }
            public DbSet<Product> Products { get; set; }
        }

        public class Manufacturer
        {
            public int ManufacturerId { get; set; }
            public string ManufacturerName { get; set; }

            public List<Product> Products { get; set; }
        }

        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }

            public int ManufacturerId { get; set; }
            public Manufacturer Manufacturer { get; set; }
        }
}
