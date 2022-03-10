using Microsoft.Extensions.DependencyInjection;
using ViksWares.Services;
using System;

namespace ViksWares
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            var host = AppService.CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<AppService>().Run();
        }
       
    }
}
