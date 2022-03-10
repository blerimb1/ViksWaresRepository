﻿using System;
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

                if (item.Name.ToLower().Contains("tickets"))
                {
                    _concertTicketsService.UpdateItemValues(item);
                }

                if (item.Name.ToLower().Contains("refrigerated"))
                {
                    _refrigeratedItemsService.UpdateItemValues(item);
                }

                if (!isSpecialItem(item.Name))
                {
                    _otherItemService.UpdateItemValues(item);
                }

            }

                     
        }

        public bool isSpecialItem(string name)
        {
            bool result = name.Equals("Aged Parmigiano") ? true : name.ToLower().Contains("tickets") ? true : (name == "Saffron Powder") ? true : name.ToLower().Contains("refrigerated")? true : false;
            return result;
        }
    }
}
