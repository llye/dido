using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using databaseLayerProject.Models.Mock;

namespace databaseLayerProject.Models
{
    public class shopDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ducani> Stores { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Prodavac> Users { get; set; }
        public DbSet<Narudzbe> Orders { get; set; }
        public shopDbContext() : base("shopDbContext", throwIfV1Schema: false) { }
        public static shopDbContext Create()
        {
            return new shopDbContext();
        }
    }    

}