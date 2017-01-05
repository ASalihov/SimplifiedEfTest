namespace SimplifiedEfTest.Migrations
{
    using Models;
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
            context.Countries.AddOrUpdate(
              p => p.Id,
              new Country { Id = 1, Name = "Russia" },
              new Country { Id = 2, Name = "USA" },
              new Country { Id = 3, Name = "Japan" }
            );
            context.Cities.AddOrUpdate(
              p => p.Id,
              new City { Name = "Moscow", CountryId = 1, Population = 2, Age = 400 },
              new City { Name = "New york", CountryId = 2, Population = 1, Age = 200 },
              new City { Name = "Tokyo", CountryId = 3, Population = 2, Age = 250 }
            );
            //
        }
    }
}
