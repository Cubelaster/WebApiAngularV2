using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
