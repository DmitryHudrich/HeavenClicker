using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class Stats
    {
        public Stats(string name)
        {
            this.StatName = name;
        }

        public readonly string StatName;

        public double Count { get; set; }
        public double Base { get; set; } = 0;

    }
}
