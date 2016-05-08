using System.Data.Entity;

namespace AgataKondraczykLab5.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
    }
}