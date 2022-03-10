using NUnit.Framework;
using ViksWares.Models;
using ViksWares.Services;

namespace ViksWaresTests
{
    public class Tests
    {
        private Item otherItem;
        private Item agedParmigiano;
        private Item concertTicket;
        private Item refrigeratedItem;

        [SetUp]
        public void Setup()
        {
            otherItem = new Item {Name = "Shoe Laces", SellBy = 10, Value = 20 };
            agedParmigiano = new Item { Name = "Aged Parmigiano", SellBy = 2, Value = 0 };
            concertTicket = new Item { Name = "Concert Tickets", SellBy = 10, Value = 20 };
            refrigeratedItem = new Item { Name = "Refrigerated pizza", SellBy = 4, Value = 10 };
        }

        [Test]
        public void TestAgedParmigianoUpdateValue()
        {
            var agedParmigianoService = new AgedParmigianoService();
            agedParmigianoService.UpdateItemValues(agedParmigiano);
            Assert.AreEqual(1, agedParmigiano.Value);
        }

        [Test]
        public void TestConcertTicketsUpdateValue()
        {
            var concertTicketsService = new ConcertTicketsService();
            concertTicketsService.UpdateItemValues(concertTicket);
            Assert.AreEqual(22, concertTicket.Value);
        }

        [Test]
        public void TestOtherItemsUpdateValue()
        {
            var otherItemService = new OtherItemService();
            otherItemService.UpdateItemValues(otherItem);
            Assert.AreEqual(19, otherItem.Value);
        }

        [Test]
        public void TestRefrigeratedItemsUpdateValue()
        {
            var refrigeratedItemService = new RefrigeratedItemsService();
            refrigeratedItemService.UpdateItemValues(refrigeratedItem);
            Assert.AreEqual(8, refrigeratedItem.Value);
        }
    }
}