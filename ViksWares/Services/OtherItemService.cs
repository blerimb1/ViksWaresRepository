using ViksWares.Interfaces;
using ViksWares.Models;
using System;


namespace ViksWares.Services
{
    public class OtherItemService : IProductService
    {
        public void UpdateItemValues(Item item)
        {
            
            if (item.SellBy >= 0)
            {
                if (item.Value > 0)
                {
                    item.Value -= 1;
                }
            }


            if (item.SellBy < 0)
            {
                if (item.Value > 1)
                {
                    item.Value -= 2;
                }
                else
                {
                    item.Value = 0;
                }    
            }
                      
        }
    }
}
