using NM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NM.Utils
{
    public class NMContext : DbContext
    {
        public static bool IsLicenseValid()
        {
            //return DateTime.Now <= Convert.ToDateTime("2016-02-05 23:59");
            return true;
        }

        public NMContext() : base("NMContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}