using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    class Actions
    {
        public static Action pillage = new("pillage", "вооруженное ограбление")
        {
            WeaponPrice = 1,
            CarPrice = 0,
            PeoplePrice = 1,

            WeaponPriceIncrement = 1,
            CarPriceIncrement = 0,
            PeoplePriceIncrement = 1,
            MoneyBaseIncrement = 1,
            InfoBaseIncrement = 0.5,
            IdeologyBaseIncrement = 0.05,
            Chance = 0.1
        };
        public static Action massMurder = new("pillage", "вооруженное ограбление")
        {
            WeaponPrice = 5,
            CarPrice = 1,
            PeoplePrice = 3,

            WeaponPriceIncrement = 2,
            CarPriceIncrement = 1,
            PeoplePriceIncrement = 2,
            MoneyBaseIncrement = 2.5,
            InfoBaseIncrement = 1,
            IdeologyBaseIncrement = 0.2,
            Chance = 0.2
        };
        public static Action explosion = new("pillage", "вооруженное ограбление")
        {
            WeaponPrice = 10,
            CarPrice = 3,
            PeoplePrice = 5,

            WeaponPriceIncrement = 1,
            CarPriceIncrement = 0,
            PeoplePriceIncrement = 1,
            MoneyBaseIncrement = 4,
            InfoBaseIncrement = 2,
            IdeologyBaseIncrement = 1,
            Chance = 0.33
        };
    }
}
