using ViksWares.Models;
using System;
using System.Collections.Generic;


namespace ViksWares.Interfaces
{
    public interface IItemsInventoryRepository
    {
        public void AddStock(Item item);
        public List<Item> GetItemInventory();
        
    }
}
