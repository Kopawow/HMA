using AgataKondraczykLab5.Models;

namespace AgataKondraczykLab5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AgataKondraczykLab5.Models.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AgataKondraczykLab5.Models.EFDbContext context)
        {
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
            context.Pizzas.AddOrUpdate(p => p.Name, 
                new Pizza() {Id = 1, Name = "Salami", Ingredients = "ser, sos pomidorowy, salami"},
                new Pizza() {Id = 2, Name = "Margharita", Ingredients = "ser, sos pomidorowy"},
                new Pizza() {Id = 3, Name = "Hawajska", Ingredients = "ser, sos pomidorowy, szynka, ananas"});
        }
    }
}
