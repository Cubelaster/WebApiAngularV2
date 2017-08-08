using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace WebApiAngularV2
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      #region OnServerRun
      var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();
      app.Run(async (context) =>
      {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("<p>Hosted by Kestrel</p>");

        if (serverAddressesFeature != null)
        {
          await context.Response.WriteAsync("<p>Listening on the following addresses: " +
            string.Join(", ", serverAddressesFeature.Addresses) + "</p>");
        }

        await context.Response.WriteAsync($"<p>Request URL: {context.Request.GetDisplayUrl()}<p>");
      });
      #endregion OnServerRun

      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 &&
           !Path.HasExtension(context.Request.Path.Value) &&
           !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMvc();
      // Configures application for usage as API
      // with default route of 'api/[Controller]'
      app.UseMvcWithDefaultRoute();
    }
  }
}
