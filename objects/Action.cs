using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class Action
    {
        readonly public string Name;
        readonly public string StatusName;
        public int Count = 0;
        public int WeaponPrice { get; set; } = 0;
        public int CarPrice { get; set; } = 0;
        public int PeoplePrice { get; set; } = 0;

        public int WeaponPriceIncrement = 0;
        public int CarPriceIncrement = 0;
        public int PeoplePriceIncrement = 0;
        public double MoneyBaseIncrement = 0;
        public double InfoBaseIncrement = 0;
        public double IdeologyBaseIncrement = 0;
        public double Chance = 0;

        public static int ObjectCount = 0;

        public Action(string name, string statusName)
        {
            Name = name;
            StatusName = statusName;
        }
    }
}
