using DAL.Models;
using DAL.Models.IdentityClasses;
using DAL.Models.Security;
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
            private IConfiguration _configuration;
            private string _connectionString = "HeroConnection";

            public HeroContextFactory() { }

            public HeroContext Create(DbContextFactoryOptions options)
            {
                return Create(
                    options.ContentRootPath,
                    options.EnvironmentName);
            }

            private HeroContext Create(string contentRootPath, string environmentName)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

                _configuration = builder.Build();
                var connection = _configuration.GetConnectionString(_connectionString);

                if (String.IsNullOrWhiteSpace(connection))
                {
                    throw new InvalidOperationException(
                        $"Could not find a connection string named {_connectionString}.");
                }
                else
                {
                    return Create(connection);
                }
            }

            private HeroContext Create(string connectionString)
            {
                if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentException(
                        $"{nameof(connectionString)} is null or empty.",
                        nameof(connectionString));

                var optionsBuilder =
                    new DbContextOptionsBuilder<HeroContext>();

                optionsBuilder.UseSqlServer(connectionString);

                return new HeroContext(optionsBuilder.Options);
            }
        }
        #endregion Migrations Hack

        public DbSet<Claims> Claims { get; set; }
    }
}
