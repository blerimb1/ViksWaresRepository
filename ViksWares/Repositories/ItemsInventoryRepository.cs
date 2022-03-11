using ViksWares.Interfaces;
using ViksWares.Models;
using System;
using System.Collections.Generic;


namespace ViksWares.Repositories
{

    public class ItemsInventoryRepository : IItemsInventoryRepository
    {
        private readonly List<Item> itemInventory = Setup();

        private static List<Item> Setup()
        {
            var itemInventory = new List<Item>();           
            return itemInventory;
        }

        public void AddStock(Item item)
        {
            itemInventory.Add(item);
        }

        public List<Item> GetItemInventory()
        {
            return itemInventory;
        }
      
    }
}
