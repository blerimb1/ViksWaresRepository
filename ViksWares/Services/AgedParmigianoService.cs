using System;
using ViksWares.Interfaces;
using ViksWares.Models;

namespace ViksWares.Services
{
    public class AgedParmigianoService : IProductService
    {     
        public void UpdateItemValues(Item item)
        {
            if(item.Value < 49)
            {
                item.Value += 1;
            }      
        }

    }
}
