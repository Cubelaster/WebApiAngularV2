using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL
{
    public class HeroContext : DbContext
    {
        public HeroContext() : base() { }
        public HeroContext(DbContextOptions<HeroContext> options, ILogger<HeroContext> _logger) : base(options)
        {
            _logger.LogDebug("Creating new HeroContext!");
        }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
