using NUnit.Framework;
using ViksWares.Factories;
using ViksWares.Interfaces;
using ViksWares.Repositories;

namespace ViksWaresTests
{
    class ItemsInventoryRepositoryTest
    {
        private IItemsInventoryRepository itemsInventoryRepository;
        private IItemFactory itemFactory;

        [SetUp]
        public void Setup()
        {
            itemsInventoryRepository = new ItemsInventoryRepository();
            itemFactory = new ItemFactory();
        }

        [Test]
        public void TestItemsInventoryRepository()
        {
            itemsInventoryRepository.AddStock(itemFactory.GetItem("Shoe Laces", 10, 20));           
            var items = itemsInventoryRepository.GetItemInventory();
            
            Assert.That(items, Is.Not.Empty);
            
        }
    }
}
