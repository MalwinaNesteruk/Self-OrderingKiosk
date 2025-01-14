using Microsoft.EntityFrameworkCore;
using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.db.ModelEmployee;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Ordering_Kiosk.db
{
    public class KioskContext : DbContext
    {
        // user
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductsOrders> ProductsOrders { get; set; }

        // employee
        public DbSet<Employee> Employees { get; set; }


        public KioskContext()
        {
        }

        public KioskContext(DbContextOptions<KioskContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = ConfigurationManager.ConnectionStrings["Dbconnection"].ToString();
            optionsBuilder.UseSqlServer(connString);
        }
    }
}