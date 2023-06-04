using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class Itemss : Stats
    {
        public Itemss(string name) : base(name)
        {      
        }

        public string Name { get; set; }

        public Dictionary<string, double> Prices { get; private set; } = new Dictionary<string, double>();

        public static int ObjectCount = 0;

        public void AddPrice(MainStats stats, double price)
        {
            Prices.Add(stats.StatName, price);
        }
        
    }
}
