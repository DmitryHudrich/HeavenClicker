using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class Item
    {
        readonly public string Name;
        readonly public string StatusName;
        public int Count = 0;
        public double MoneyPrice { get; set; } = 0;
        public double InfoPrice { get; set; } = 0;
        public double IdeologyPrice { get; set; } = 0;

        public double MoneyPriceMultiplier = 0;
        public double InfoPriceMultiplier = 0;
        public double IdeologyPriceMultiplier  = 0 ;

        public static int ObjectCount = 0;

        public Item(string name, string statusName)
        {
            Name = name;
            StatusName = statusName;
        }
    }
}
