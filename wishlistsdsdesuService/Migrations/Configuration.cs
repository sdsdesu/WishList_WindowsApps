namespace wishlistsdsdesuService.Migrations
{
    using Microsoft.Azure.Mobile.Server.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wishlistsdsdesuService.DataObjects;

    internal sealed class Configuration : DbMigrationsConfiguration<wishlistsdsdesuService.Models.wishlistsdsdesuContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }

        protected override void Seed(wishlistsdsdesuService.Models.wishlistsdsdesuContext context)
        {
            List<Person> persons = new List<Person>
            {
                new Person { Id = Guid.NewGuid().ToString(), FirstName = "Timo", LastName = "Spanhove", Email = "Impling@UberDnD.co.uk", Password = "ChickenYUCrossRoad1" },
                new Person { Id = Guid.NewGuid().ToString(), FirstName = "Victor", LastName = "Van Weyenberg", Email = "SirAldric@UberDnD.co.uk", Password = "ChickenYUCrossRoad1" }
            };

            context.Persons.AddOrUpdate(persons[0], persons[1]);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
