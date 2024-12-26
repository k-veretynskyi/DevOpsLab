using DevOps_Lab1.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Lab1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base(options) 
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet <Country> Countries { get; set; }
    }
}
