using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class Activities : Stats
    {
        public Activities(string name) : base(name)
        {
        }

        public int Price { get; set; } = 0;

        public int PriceIncrement = 0;

        public double Chance = 0;

    }
}
