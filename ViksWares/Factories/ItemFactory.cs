using ViksWares.Interfaces;
using ViksWares.Models;
using System;

namespace ViksWares.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item GetItem(string name, int sellBy, int value)
        {
             return new Item { Name = name, SellBy = sellBy, Value = value };           
        }
    }
}
