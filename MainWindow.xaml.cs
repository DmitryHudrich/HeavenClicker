using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeavenClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isItemsMenuOpen = false;
        private bool _isActionsMenuOpen = false;

        MainStats money = new("money");
        MainStats information = new("information");
        MainStats ideology = new("money");

        Activities pillage = new("pillage");
        Activities massMurder = new("massMurder");
        Activities explosion = new("explosion");

        Itemss weapon = new("weapon");
        Itemss car = new("car");
        Itemss people = new("people");

        public void UpdateMainCounters()
        {
            MoneyCounterTextBox.Text = "Деньги: " + Math.Round(money.Count, 2);
            InfoCounterTextBox.Text = "Информация: " + Math.Round(information.Count, 2);
            IdeologyCounterTextBox.Text = "Идеология: " + Math.Round(ideology.Count, 2) ;
        }

        public void UpdateSecondaryCounters()
        {
            WeaponCounterTextBox.Text = "Пушек: " + weapon.Count;
            CarCounterTextBox.Text = "Машин: " + car.Count;
            PeopleCounterTextBox.Text = "Людей: " + people.Count;
        }

        public void UpdateItemCounters()
        {
            WeaponMoneyPriceCounter.Text = "Деньги: " + Math.Round(weapon.Prices["money"], 2);
            WeaponInfoPriceCounter.Text = "Информация: " + Math.Round(weapon.Prices["information"], 2);
            CarMoneyPriceCounter.Text = "Деньги: " + Math.Round(car.Prices["money"], 2);
            CarInfoPriceCounter.Text = "Информация: " + Math.Round(car.Prices["information"], 2);
            CarIdeologyPriceCounter.Text = "Идеология: " + Math.Round(car.Prices["ideology"], 2);
            PeopleMoneyPriceCounter.Text = "Деньги: " + Math.Round(people.Prices["money"], 2);
            PeopleInfoPriceCounter.Text = "Информация: " + Math.Round(people.Prices["information"], 2);
            PeopleIdeologyPriceCounter.Text = "Идеология: " + Math.Round(people.Prices["ideology"], 2);
        }

        public void UpdateActionCounters()
        {
            PillageWeaponPriceCounter.Text = "Оружия:" + Actions.pillage.WeaponPrice;
            PillagePeoplePriceCounter.Text = "Людей:" + Actions.pillage.PeoplePrice;
            PillageChanceCounter.Text = "Шанс неудачи: " + Math.Round(Actions.pillage.Chance * 100, 2) + "%"; 
            MassMurderWeaponPriceCounter.Text = "Оружия:" + Actions.massMurder.WeaponPrice;
            MassMurderCarPriceCounter.Text = "Машин:" + Actions.massMurder.CarPrice;
            MassMurderPeoplePriceCounter.Text = "Людей:" + Actions.massMurder.PeoplePrice;
            MassMurderChanceCounter.Text = "Шанс неудачи: " + Math.Round(Actions.massMurder.Chance * 100, 2) + "%";
            ExplosionWeaponPriceCounter.Text = "Оружия:" + Actions.explosion.WeaponPrice;
            ExplosionCarPriceCounter.Text = "Машин:" + Actions.explosion.CarPrice;
            ExplosionPeoplePriceCounter.Text = "Людей:" + Actions.explosion.PeoplePrice;
            ExplosionChanceCounter.Text = "Шанс неудачи: " + Math.Round(Actions.explosion.Chance * 100, 2) + "%";
        }
        public MainWindow()
        {
            InitializeComponent();
            Foo();

            UpdateActionCounters();
        }

        private void Foo()
        {
            try
            {
                weapon.AddPrice(money, 5);
                weapon.AddPrice(information, 5);
                weapon.AddPrice(ideology, 5);
            }
            catch
            {

            }
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            Variables.Money += Variables.MoneyBase + Variables.rnd.NextDouble() * Variables.MoneyBonus;
            Variables.Info += Variables.InfoBase + Variables.rnd.NextDouble() * Variables.InfoBonus;
            Variables.Ideology += Variables.IdeologyBase + Variables.rnd.NextDouble() * Variables.IdeologyBonus;

            UpdateMainCounters();
        }

        private Itemss InventoryObjectSelector(string tag)
        {
            var obj = new Dictionary<string, Itemss>()
            {
                { "weapon", weapon},
                { "car", car},
                { "people", people}
            };

            return obj[tag];
        }

        private Activities ActionSelector(string tag)
        {
            

            var act = new Dictionary<string, Activities>()
            {
                { "pillage", pillage},
                { "massMurder", massMurder},
                { "explosion", explosion}
            };

            return act[tag];
        }

        private void BuyItem(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string objName = button.Tag as string;
            Itemss tempObj = InventoryObjectSelector(objName);

            if (Variables.Money >= tempObj.Prices["money"] && Variables.Info >= tempObj.Prices["information"] && Variables.Ideology >= tempObj.Prices["ideology"])
            {
                tempObj.Count++;
                Itemss.ObjectCount++;
                money.Count -= tempObj.Prices["money"];
                information.Count -= tempObj.Prices["information"];
                ideology.Count -= tempObj.Prices["ideology"];

                tempObj.Prices["money"] *= 1.5;  // tempObj.MoneyPriceMultiplier;
                tempObj.Prices["information"] *= 1.5; // tempObj.InfoPriceMultiplier;
                tempObj.Prices["ideology"] *= 1.5;  // tempObj.IdeologyPriceMultiplier;

                UpdateMainCounters();
                UpdateSecondaryCounters();
                UpdateItemCounters();
                StatusTextBox.Text = "Ты купил " + tempObj.Name; ;
            }
            else
            {
                StatusTextBox.Text = "Недостаточно ресурсов!";
            }
        }

        private void BuyAction(object sender, RoutedEventArgs e)
        {
            //var button = sender as Button;
            //string objName = button.Tag as string;
            //Activities tempObj = ActionSelector(objName);

            //if (weapon.Count >= tempObj.WeaponPrice && car.Count >= tempObj.CarPrice && people.Count >= tempObj.PeoplePrice)
            //{
            //    tempObj.Count++;
            //    Action.ObjectCount++;
            //    Itemss.ObjectCount -= tempObj.WeaponPrice - tempObj.CarPrice - tempObj.PeoplePrice;

            //    Items.weapon.Count -= tempObj.WeaponPrice;
            //    Items.car.Count -= tempObj.CarPrice;
            //    Items.people.Count -= tempObj.PeoplePrice;

            //    if (1 - Variables.rnd.NextDouble() < tempObj.Chance)
            //    {
            //        StatusTextBox.Text = "Ты совершил неудачное " + tempObj.StatusName;
            //    }
            //    else
            //    {
            //        Variables.MoneyBase += tempObj.MoneyBaseIncrement;
            //        Variables.InfoBase += tempObj.InfoBaseIncrement;
            //        Variables.IdeologyBase += tempObj.IdeologyBaseIncrement;

            //        tempObj.WeaponPrice += tempObj.WeaponPriceIncrement;
            //        tempObj.CarPrice += tempObj.CarPriceIncrement;
            //        tempObj.PeoplePrice += tempObj.PeoplePriceIncrement;
            //        tempObj.Chance += 0.05;

            //        StatusTextBox.Text = "Ты совершил успешное " + tempObj.StatusName;
            //    }




            //    UpdateMainCounters();
            //    UpdateSecondaryCounters();
            //    UpdateItemCounters();
            //    UpdateActionCounters();

            //}
            //else
            //{
            //    StatusTextBox.Text = "Недостаточно ресурсов!";
            //}
        }

        private void OpenItemsMenuButton(object sender, RoutedEventArgs e)
        {
            if (_isItemsMenuOpen)
            {
                GridLength gridLengthValue = (GridLength)new GridLengthConverter().ConvertFrom("0".ToString());

                ItemsGridSection.Width = gridLengthValue;
                _isItemsMenuOpen = false;
            }

            else
            {
                GridLength gridLengthValue = (GridLength)new GridLengthConverter().ConvertFrom("1*".ToString());

                ItemsGridSection.Width = gridLengthValue;
                _isItemsMenuOpen = true;
            }
        }

        private void OpenActionsMenuButton(object sender, RoutedEventArgs e)
        {
            if (_isActionsMenuOpen)
            {
                GridLength gridLengthValue = (GridLength)new GridLengthConverter().ConvertFrom("0".ToString());

                ActionsGridSection.Width = gridLengthValue;
                _isActionsMenuOpen = false;
            }

            else
            {
                GridLength gridLengthValue = (GridLength)new GridLengthConverter().ConvertFrom("1*".ToString());

                ActionsGridSection.Width = gridLengthValue;
                _isActionsMenuOpen = true;
            }
        }
    }
}
