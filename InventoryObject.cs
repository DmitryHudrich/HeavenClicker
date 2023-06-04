using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class InventoryObject
    {
        readonly public string Name;
        public int Count = 0;
        public double Price;
        readonly public double PriceMultiplier;
        public static int ObjectCount = 0;

        public InventoryObject(string name, double price, double priceMultiplier){
            Name = name;
            Price = price;
            PriceMultiplier = priceMultiplier;
        }
    }
}
