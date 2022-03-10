using ViksWares.Interfaces;
using ViksWares.Models;
using System;

namespace ViksWares.Services
{
    public class RefrigeratedItemsService : IProductService
    {
        public void UpdateItemValues(Item item)
        {

            if (item.SellBy >= 0)
            {
                if (item.Value > 1)
                {
                    item.Value -= 2;
                }
            }
            else
            {
                if (item.Value > 3)
                {
                    item.Value -= 4;
                }
                else
                {
                    item.Value = 0;
                }
            }

        }
    }
}