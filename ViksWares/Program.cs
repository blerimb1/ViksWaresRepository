using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ViksWares.Services;
using System;
using System.Collections.Generic;
using ViksWares.Repositories;
using ViksWares.Interfaces;
using ViksWares.Factories;

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
