using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    class Items
    {
        public static Item weapon = new("weapon", "пушку")
        {
            MoneyPrice = 5,
            InfoPrice = 2,
            MoneyPriceMultiplier = 1.1,
            InfoPriceMultiplier = 1.2
        };

        public static Item car = new("car", "тачку")
        {
            MoneyPrice = 50,
            InfoPrice = 10,
            IdeologyPrice = 1,
            MoneyPriceMultiplier = 1.5,
            InfoPriceMultiplier = 1.1,
            IdeologyPriceMultiplier = 1.1
        };

        public static Item people = new("people", "человека")
        {
            MoneyPrice = 5,
            InfoPrice = 10,
            IdeologyPrice = 1,
            MoneyPriceMultiplier = 1.3,
            InfoPriceMultiplier = 1.2,
            IdeologyPriceMultiplier = 1.3
        };
    }
}
