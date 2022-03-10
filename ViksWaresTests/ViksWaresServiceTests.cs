using NUnit.Framework;
using System.Collections.Generic;
using ViksWares.Models;
using ViksWares.Services;
using ViksWares.Interfaces;
using static ViksWares.Program;
using static ViksWares.Services.AppService;

namespace ViksWaresTests
{
    class ViksWaresServiceTests
    {

        List<Item> itemsInStock;
        ServiceResolver serviceResolver;
        ViksWaresService viksWaresService;

        [SetUp]
        public void Setup()
        {
            itemsInStock = new List<Item>{
                new Item {Name = "Shoe Laces", SellBy = 10, Value = 20},
                new Item {Name = "Aged Parmigiano", SellBy = 2, Value = 0},
                new Item {Name = "Book of Resolutions", SellBy = 5, Value = 7},
                new Item {Name = "Saffron Powder", SellBy = 0, Value = 80},
                new Item {Name = "Saffron Powder", SellBy = -1, Value = 80},
                new Item {Name = "Concert tickets to Talkins Festival", SellBy = 15, Value = 20},
                new Item {Name = "Concert tickets to Talkins Festival", SellBy = 10, Value = 49},
                new Item {Name = "Concert tickets to Talkins Festival", SellBy = 5, Value = 49},
                new Item {Name = "Refrigerated milk", SellBy = 3, Value = 6}
                };
            serviceResolver = new ServiceResolver(ProductService);
            viksWaresService = new ViksWaresService(serviceResolver);
        }

       

        private IProductService ProductService(string name)
        {
            return name switch {
                "AgedParmigiano" => new AgedParmigianoService(),
                "ConcertTickets" => new ConcertTicketsService(),
                "RefrigeratedItems" => new RefrigeratedItemsService(),
                "OtherItem" => new OtherItemService(),
                _ => null
            };
        }

        [Test]
        public void TestViksWaresServiceUpdateValue()
        {

            for (var i = 0; i < 4; i++)
            {
                 viksWaresService.UpdateValue(itemsInStock);
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(16, itemsInStock[0].Value);
                Assert.AreEqual(6, itemsInStock[0].SellBy);
                Assert.AreEqual(4, itemsInStock[1].Value);
                Assert.AreEqual(-2, itemsInStock[1].SellBy);
                Assert.AreEqual(3, itemsInStock[2].Value);
                Assert.AreEqual(1, itemsInStock[2].SellBy);
                Assert.AreEqual(80, itemsInStock[3].Value);
                Assert.AreEqual(0, itemsInStock[3].SellBy);
                Assert.AreEqual(80, itemsInStock[4].Value);
                Assert.AreEqual(-1, itemsInStock[4].SellBy);
                Assert.AreEqual(24, itemsInStock[5].Value);
                Assert.AreEqual(11, itemsInStock[5].SellBy);
                Assert.AreEqual(50, itemsInStock[6].Value);
                Assert.AreEqual(6, itemsInStock[6].SellBy);
                Assert.AreEqual(50, itemsInStock[7].Value);
                Assert.AreEqual(1, itemsInStock[7].SellBy);
                Assert.AreEqual(0, itemsInStock[8].Value);
                Assert.AreEqual(-1, itemsInStock[8].SellBy);               
            });
        }

        public void TestViksWaresServiceUpdateValue_2()
        {

            for (var i = 0; i < 2; i++)
            {
               viksWaresService.UpdateValue(itemsInStock);
            }

            Assert.Multiple(() =>
            {
                Assert.AreEqual(50, itemsInStock[7].Value);
                Assert.AreEqual(3, itemsInStock[7].SellBy);
                Assert.AreEqual(2, itemsInStock[8].Value);
                Assert.AreEqual(1, itemsInStock[8].SellBy);
            });
        }

    }
}
