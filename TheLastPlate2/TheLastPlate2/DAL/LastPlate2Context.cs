using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheLastPlate2.Models;

namespace TheLastPlate2.Models
{
    public class LastPlate2Context : DbContext
    {
        public LastPlate2Context() : base("LastPlate2Context") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cust_Password> Cust_Passwords { get; set; }

        public System.Data.Entity.DbSet<TheLastPlate2.Models.TXN> TXNs { get; set; }

        public System.Data.Entity.DbSet<TheLastPlate2.Models.Business> Businesses { get; set; }

        public System.Data.Entity.DbSet<TheLastPlate2.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<TheLastPlate2.Models.Listing> Listings { get; set; }

        public DbSet<Business_Password> Business_Passwords { get; set; }
        //public DbSet<BP2> bP2s { get; set; }

    }
}