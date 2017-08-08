using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace WebApiAngularV2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Running API with Kestrel!");

      var host = new WebHostBuilder()
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseStartup<Startup>()
          .Build();

      host.Run();
    }
  }
}
