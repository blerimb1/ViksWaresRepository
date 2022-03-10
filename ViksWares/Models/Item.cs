using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViksWares.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int SellBy { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellBy + ", " + this.Value;
        }
    }
}
