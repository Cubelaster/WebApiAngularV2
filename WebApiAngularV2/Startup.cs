using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DAL;
using BL.Repository.UOW.Contracts;
using BL.Repository.UOW;
using BL.Services;
using BL.Services.ServicesContracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Models.IdentityClasses;
using System;
using AutoMapper;
using DAL.Models.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApiAngularV2
{
  public class Startup
  {
    private const string SecretKey = "CubelasterKey"; // todo: get this from somewhere secure
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

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

    public IConfigurationRoot Configuration { get; }
    private ILogger<Startup> _logger { get; set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc();

      services.AddDbContext<HeroContext>(options => 
        options.UseSqlServer(Configuration.GetConnectionString("HeroConnection")));

      // jwt wire up
      // Get options from app settings
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

      // Configure JwtIssuerOptions
      services.Configure<JwtIssuerOptions>(options =>
      {
        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
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

      services.AddAutoMapper();

      services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IProductService, ProductService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      #region OnServerRun
      // This writes instead of response. Proves server is alive.
      // It also overwrites the response. :)

      //var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();
      //app.Run(async (context) =>
      //{
      //  context.Response.ContentType = "text/html";
      //  await context.Response.WriteAsync("<p>Hosted by Kestrel</p>");

      //  if (serverAddressesFeature != null)
      //  {
      //    await context.Response.WriteAsync("<p>Listening on the following addresses: " +
      //      string.Join(", ", serverAddressesFeature.Addresses) + "</p>");
      //  }

      //  await context.Response.WriteAsync($"<p>Request URL: {context.Request.GetDisplayUrl()}<p>");
      //});
      #endregion OnServerRun

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

      app.UseStaticFiles();
      app.UseDefaultFiles();

      app.UseMvc();
      // Configures application for usage as API
      // with default route of 'api/[Controller]'
      app.UseMvcWithDefaultRoute();

      app.UseIdentity();
    }
  }
}
