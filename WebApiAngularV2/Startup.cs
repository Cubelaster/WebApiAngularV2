using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DAL;
using BL.Repository.UOW.Contracts;
using BL.Repository.UOW;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Models.IdentityClasses;
using System;
using AutoMapper;
using DAL.Models.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL.Models.HelperModels;
using BL.Security.SecurityContracts;
using BL.Security;
using FluentValidation.AspNetCore;
using BL.Controllers;
using System.Reflection;
using BL.ViewModels.Mappings.Account;
using BL.Helpers.HelperContracts;
using BL.Helpers;

namespace WebApiAngularV2
{
  public class Startup
  {
    private const string SecretKey = "UGFsYWNHb3JlWmFNZXRhbGFjDQo="; // todo: get this from somewhere secure; PalacGoreZaMetalac
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
    public IConfigurationRoot Configuration { get; }
    private ILogger<Startup> _logger { get; set; }

    public Startup(IHostingEnvironment env, ILogger<Startup> _logger)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();

      this._logger = _logger;
      Configuration = builder.Build();
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<HeroContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("HeroConnection"), opts => opts.MigrationsAssembly("DAL")));

      ConfigureServicesDI(services);

      ConfigureServicesJWT(services);

      ConfigureServicesAuthorization(services);

      services.AddMvc()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AccountController>());
      services.AddAutoMapper();
      // This is supposed to be needed, but it worsk without it as well, so... Yeah. Just keep in mind.
      //typeof(AccountViewModelsToEntityMappingProfile).GetTypeInfo().Assembly 
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory
      , IDbInitializer dbInitializer)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404
           //&& !Path.HasExtension(context.Request.Path.Value)
           //&& !context.Request.Path.Value.StartsWith("/api/")
           )
        {
          _logger.LogInformation("Redirected from 404 to index");
          context.Request.Path = "/index.html";
          await next();
        }
      });

      ConfigureJWT(app);

      dbInitializer.Initialize(Configuration);

      app.UseStaticFiles();
      app.UseDefaultFiles();

      app.UseIdentity();
      // Configures application for usage as API
      // with default route of 'api/[Controller]'
      app.UseMvcWithDefaultRoute();

    }

    #region ConfigureSErvicesSteps
    private void ConfigureServicesDI(IServiceCollection services)
    {
      services.AddSingleton<IConfiguration>(Configuration);
      services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IDbInitializer, DbInitializer>();
      services.AddSingleton<IJwtFactory, JwtFactory>();
    }

    private void ConfigureServicesJWT(IServiceCollection services)
    {
      // JWT wire up
      // Get options from app settings
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

      // Configure JwtIssuerOptions
      services.Configure<JwtIssuerOptions>(options =>
      {
        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
      });
    }

    private void ConfigureServicesAuthorization(IServiceCollection services)
    {
      // api user claim policy
      services.AddAuthorization(options =>
      {
        options.AddPolicy("ApiUser", policy => policy.RequireClaim(JwtHelpers.Strings.JwtClaimIdentifiers.Rol, JwtHelpers.Strings.JwtClaims.ApiAccess));
      });

      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.User.RequireUniqueEmail = true;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;
      })
        .AddEntityFrameworkStores<HeroContext>()
        .AddDefaultTokenProviders();
    }
    #endregion ConfigureSErvicesSteps

    #region ConfigureSteps
    private void ConfigureJWT(IApplicationBuilder app)
    {
      // JWT
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

        ValidateAudience = true,
        ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = _signingKey,

        RequireExpirationTime = false,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.Zero
      };

      app.UseJwtBearerAuthentication(new JwtBearerOptions
      {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        TokenValidationParameters = tokenValidationParameters
      });
    }
    #endregion ConfigureSteps
  }
}
