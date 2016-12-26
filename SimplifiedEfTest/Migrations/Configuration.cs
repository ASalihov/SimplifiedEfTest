namespace SimplifiedEfTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimplifiedEfTest.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimplifiedEfTest.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Cities.AddOrUpdate(
              p => p.Id,
              new Models.City { Name = "Moscow", Country = new Models.Country { Name = "Russia" } },
              new Models.City { Name = "Tashkent", Country = new Models.Country { Name = "Uzbekistan" } },
              new Models.City { Name = "New York", Country = new Models.Country { Name = "USA" } }
            );

        }
    }
}
