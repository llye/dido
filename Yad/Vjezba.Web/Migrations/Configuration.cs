namespace Vjezba.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vjezba.Web.Models.Mock;

    internal sealed class Configuration : DbMigrationsConfiguration<Vjezba.Web.Models.shopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vjezba.Web.Models.shopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Cars.AddOrUpdate(p => p.Name,
                new Car()
                {
                    Name = "Golos",
                    Brand = "BMW",
                    BuyPrice = 256,
                    SellPrice = 2333,
                    Description = "88"
                });
            context.Stores.AddOrUpdate(p => p.Name,
                new Ducani()
                {
                    Name = "Miramarska",
                    Adress = "Miramarska 23",
                    City = "Zagreb",
                    Latitude = 32,
                    Longitude = 23
                });
            context.Users.AddOrUpdate(p => p.Name, 
                new Prodavac()
            {
                ID = 0,
                Name = "Miroslav"
                
            });
            context.Kupci.AddOrUpdate(p => p.Name,
                new Kupac()
            {
               ID = 0,
               Name = "Matija Gubec",
               Email = "matija@gubec.com"
               
            });

        }
    }
}
