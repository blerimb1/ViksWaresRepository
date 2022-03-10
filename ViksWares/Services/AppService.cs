using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViksWares.Factories;
using ViksWares.Interfaces;
using ViksWares.Repositories;

namespace ViksWares.Services
{
    public class AppService
    {
        public delegate IProductService ServiceResolver(string name);

        private readonly IViksWaresService _vikWareService;
        private readonly IItemsInventoryRepository _itemsInventoryRepository;
        private readonly IItemFactory _itemfactory;

        public AppService(IViksWaresService vikWareService, IItemsInventoryRepository itemsInventoryRepository, IItemFactory itemFactory)
        {
            _vikWareService = vikWareService;
            _itemsInventoryRepository = itemsInventoryRepository;
            _itemfactory = itemFactory;
        }
        public void Run()
        {

            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Shoe Laces", 10, 20));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Aged Parmigiano", 2, 0));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Book of Resolutions", 5, 7));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Saffron Powder", 0, 80));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Saffron Powder", -1, 80));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Concert tickets to Talkins Festival", 15, 20));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Concert tickets to Talkins Festival", 10, 49));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Concert tickets to Talkins Festival", 5, 49));
            _itemsInventoryRepository.AddStock(_itemfactory.GetItem("Refrigerated milk", 3, 6));


            var items = _itemsInventoryRepository.GetItemInventory();


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j]);
                }
                Console.WriteLine("");
                _vikWareService.UpdateValue(items);
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<AppService>();
                    services.AddTransient<IItemsInventoryRepository, ItemsInventoryRepository>();
                    services.AddTransient<IItemFactory, ItemFactory>();
                    services.AddTransient<IViksWaresService, ViksWaresService>();
                    services.AddTransient<AgedParmigianoService>();
                    services.AddTransient<ConcertTicketsService>();
                    services.AddTransient<OtherItemService>();
                    services.AddTransient<RefrigeratedItemsService>();
                    services.AddTransient((Func<IServiceProvider, ServiceResolver>)(serviceProvider => name =>
                    {
                        switch (name)
                        {
                            case "AgedParmigiano":
                                return serviceProvider.GetService<AgedParmigianoService>();
                            case "ConcertTickets":
                                return serviceProvider.GetService<ConcertTicketsService>();
                            case "RefrigeratedItems":
                                return serviceProvider.GetService<RefrigeratedItemsService>();
                            case "OtherItem":
                                return serviceProvider.GetService<OtherItemService>();
                            default:
                                throw new KeyNotFoundException();
                        }
                    }));
                });
        }
    }
}
