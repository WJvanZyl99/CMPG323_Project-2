using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Database.Models;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cmpg323Context db = Cmpg323Context.init();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
