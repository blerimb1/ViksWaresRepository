using System;
using System.Collections.Generic;
using ViksWares.Models;
using ViksWares.Interfaces;

using static ViksWares.Program;
using static ViksWares.Services.AppService;

namespace ViksWares.Services
{
    public class ViksWaresService : IViksWaresService
    {
        private readonly IProductService _agedParmigianoService;
        private readonly IProductService _concertTicketsService;
        private readonly IProductService _otherItemService;
        private readonly IProductService _refrigeratedItemsService;

        public ViksWaresService(ServiceResolver serviceAccessor)
        {
            _agedParmigianoService = serviceAccessor("AgedParmigiano");
            _concertTicketsService = serviceAccessor("ConcertTickets");
            _refrigeratedItemsService = serviceAccessor("RefrigeratedItems");
            _otherItemService = serviceAccessor("OtherItem");      
        }

        public void UpdateValue(List<Item> items)
        {
            
            foreach (var item in items)
            {
                if (!item.Name.Equals("Saffron Powder"))
                {
                    item.SellBy -= 1;
                }

                if (item.Name.Equals("Aged Parmigiano"))
                {
                    _agedParmigianoService.UpdateItemValues(item);
                }
                else if (item.Name.ToLower().Contains("tickets"))
                {
                    _concertTicketsService.UpdateItemValues(item);
                }
                else if (item.Name.ToLower().Contains("refrigerated"))
                {
                    _refrigeratedItemsService.UpdateItemValues(item);
                }
                else if (!IsSpecialItem(item.Name)) 
                {
                    _otherItemService.UpdateItemValues(item);
                }
            }
                     
        }

        public static bool IsSpecialItem(string name)
        {
            bool result = name.Equals("Aged Parmigiano") || (name.ToLower().Contains("tickets") || ((name == "Saffron Powder") || (name.ToLower().Contains("refrigerated"))));
            return result;
        }
    }
}
