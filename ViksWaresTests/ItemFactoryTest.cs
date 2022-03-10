using NUnit.Framework;
using ViksWares.Factories;
using ViksWares.Interfaces;
using ViksWares.Models;

namespace ViksWaresTests
{
    class ItemFactoryTest
    {
        private IItemFactory itemFactory;       

        [SetUp]
        public void Setup()
        {
            itemFactory = new ItemFactory();
        }

        [Test]
        public void TestFactoryGetItem()
        {
            Item newItem = itemFactory.GetItem("testItem", 0, 30);
            Assert.Multiple(() =>
            {
                Assert.AreEqual("testItem", newItem.Name);
                Assert.AreEqual(0, newItem.SellBy);
                Assert.AreEqual(30, newItem.Value);
            });
        }
    }
}
