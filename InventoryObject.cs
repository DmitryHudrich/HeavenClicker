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
        public double MoneyPrice { get; set; } = 0;
        public double InfoPrice = 0;
        public double IdeologyPrice = 0;

        public double MoneyPriceMultiplier = 0;
        public double InfoPriceMultiplier = 0;
        public double IdeologyPriceMultiplier  = 0 ;

        public static int ObjectCount = 0;

        public InventoryObject(string name){
            Name = name;
        }
    }
}
