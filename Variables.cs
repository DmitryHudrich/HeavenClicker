using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenClicker
{
    internal class Variables
    {
        Random rnd = new Random();

        //количество имеющихся у игрока ресурсов
        public static double Money { get; set; } = 0;
        public static double Info { get; set; } = 0;
        public static double Ideology { get; set; } = 0;

        //база того, сколько за клик получаешь хуйни
        public static double MoneyBase { get; set; } = 0;
        public static double InfoBase { get; set; } = 0;
        public static double IdeologyBase { get; set; } = 0;
        
        //надбавка того, что ты получаешь за клик
        public static double MoneyBonus { get; set; } = 0;
        public static double InfoBonus { get; set; } = 0;
        public static double IdeologyBonus { get; set; } = 0;

        //количество имеющихся у игрока консюмаблов
        public static double Weapons { get; set; } = 0;
        public static double Bombs { get; set; } = 0;
        public static double People { get; set; } = 0;

        //цены на консюмаблы
        public static double WeaponMoneyPrice { get; set; } = 0;
        public static double BombMoneyPrice { get; set; } = 0;
        public static double PeopleMoneyPrice { get; set; } = 0;

        public static double WeaponInfoPrice { get; set; } = 0;
        public static double BombInfoPrice { get; set; } = 0;
        public static double PeopleInfoPrice { get; set; } = 0;

        public static double WeaponIdeologyPrice { get; set; } = 0;
        public static double BombIdeologyPrice { get; set; } = 0;
        public static double PeopleIdeologyPrice { get; set; } = 0;

        //умножители цен на консюмаблы
        public static double WeaponMoneyPriceMultiplier { get; set; } = 0;
        public static double BombMoneyPriceMultiplier { get; set; } = 0;
        public static double PeopleMoneyPriceMultiplier { get; set; } = 0;

        public static double WeaponInfoPriceMultiplier { get; set; } = 0;
        public static double BombInfoPriceMultiplier { get; set; } = 0;
        public static double PeopleInfoPriceMultiplier { get; set; } = 0;

        public static double WeaponIdeologyPriceMultiplier { get; set; } = 0;
        public static double BombIdeologyPriceMultiplier { get; set; } = 0;
        public static double PeopleIdeologyPriceMultiplier { get; set; } = 0;



    }
}
