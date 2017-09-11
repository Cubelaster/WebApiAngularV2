using DAL.Models;
using DAL.Models.IdentityClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace DAL
{
    public class HeroContext : IdentityDbContext<ApplicationUser>
    {
        public HeroContext() : base() { }
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }
        public HeroContext(DbContextOptions<HeroContext> options, ILogger<HeroContext> _logger) : base(options)
        {
            _logger.LogDebug("Creating new HeroContext!");
        }

        #region Migrations Hack
        public class HeroContextFactory : IDbContextFactory<HeroContext>
        {
            private IConfigurationRoot configuration;

            public HeroContextFactory()
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(System.AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                // Here is a bit of a problem:
                // My DAL project can not fetch the required connection string from Web project
                // That's why this factory
                // It gets triggered on Add-Migration
                configuration = builder.Build();
            }

            public HeroContext Create(DbContextFactoryOptions options)
            {
                var optionsBuilder = new DbContextOptionsBuilder<HeroContext>();
                var connection = configuration.GetConnectionString("HeroConnection");
                connection = connection == null ? "Server=DESKTOP-M9BFD6K;Database=Hero;User Id=sa;Password=Password11__" : connection;
                optionsBuilder.UseSqlServer(connection, m => { m.EnableRetryOnFailure(); });

                return new HeroContext(optionsBuilder.Options);
            }
        }
        #endregion Migrations Hack

        public DbSet<Hero> Hero { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
