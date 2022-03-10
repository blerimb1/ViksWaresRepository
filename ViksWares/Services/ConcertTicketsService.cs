using System;
using ViksWares.Interfaces;
using ViksWares.Models;

namespace ViksWares.Services
{
    public class ConcertTicketsService : IProductService
    {
        
        public void UpdateItemValues(Item item)
        {
            if (item.SellBy > 0)
            {
                if (item.Value < 50)
                {
                    item.Value += 1;
                }

                if (item.SellBy < 11)
                {
                    if (item.Value < 50)
                    {
                        item.Value += 1;
                    }
                }

                if (item.SellBy < 6)
                {
                    if (item.Value < 50)
                    {
                        item.Value += 1;
                    }
                }
            }
            else
            {
                item.Value = 0;
            }
        }
    }
}
