using ViksWares.Models;
using System;


namespace ViksWares.Interfaces
{
    public interface IItemFactory
    {
        public Item GetItem(string name, int sellBy, int value);
    }
}
