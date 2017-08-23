using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M9BFD6K;Database=Hero;User Id=sa;Password=Password11__");
        }

        public DbSet<Hero> Hero { get; set; }
    }
}
