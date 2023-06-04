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

        public void UpdateMainCounters()
        {
            MoneyCounterTextBox.Text = "Деньги: " + Math.Round(Variables.Money, 2);
            InfoCounterTextBox.Text = "Информация: " + Math.Round(Variables.Info, 2);
            IdeologyCounterTextBox.Text = "Идеология: " + Math.Round(Variables.Ideology, 2);
        }

        public void UpdateSecondaryCounters()
        {
            WeaponCounterTextBox.Text = "Пушек: " + Items.weapon.Count;
            CarCounterTextBox.Text = "Машин: " + Items.car.Count;
            PeopleCounterTextBox.Text = "Людей: " + Items.people.Count;
        }

        public void UpdateItemCounters()
        {
            WeaponMoneyPriceCounter.Text = "Деньги: " + Math.Round(Items.weapon.MoneyPrice, 2);
            WeaponInfoPriceCounter.Text = "Информация: " + Math.Round(Items.weapon.InfoPrice, 2);
            CarMoneyPriceCounter.Text = "Деньги: " + Math.Round(Items.car.MoneyPrice, 2);
            CarInfoPriceCounter.Text = "Информация: " + Math.Round(Items.car.InfoPrice, 2);
            CarIdeologyPriceCounter.Text = "Идеология: " + Math.Round(Items.car.IdeologyPrice, 2);
            PeopleMoneyPriceCounter.Text = "Деньги: " + Math.Round(Items.people.MoneyPrice, 2);
            PeopleInfoPriceCounter.Text = "Информация: " + Math.Round(Items.people.InfoPrice, 2);
            PeopleIdeologyPriceCounter.Text = "Идеология: " + Math.Round(Items.people.IdeologyPrice, 2);
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
            UpdateActionCounters();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            Variables.Money += Variables.MoneyBase + Variables.rnd.NextDouble() * Variables.MoneyBonus;
            Variables.Info += Variables.InfoBase + Variables.rnd.NextDouble() * Variables.InfoBonus;
            Variables.Ideology += Variables.IdeologyBase + Variables.rnd.NextDouble() * Variables.IdeologyBonus;

            UpdateMainCounters();
        }

        private Item InventoryObjectSelector(string tag)
        {
            var obj = new Dictionary<string, Item>()
            {
                { "weapon", Items.weapon},
                { "car", Items.car},
                { "people", Items.people}
            };

            return obj[tag];
        }

        private Action ActionSelector(string tag)
        {
            var act = new Dictionary<string, Action>()
            {
                { "pillage", Actions.pillage},
                { "massMurder", Actions.massMurder},
                { "explosion", Actions.explosion}
            };

            return act[tag];
        }

        private void BuyItem(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string objName = button.Tag as string;
            Item tempObj = InventoryObjectSelector(objName);

            if (Variables.Money >= tempObj.MoneyPrice && Variables.Info >= tempObj.InfoPrice && Variables.Ideology >= tempObj.IdeologyPrice)
            {
                tempObj.Count++;
                Item.ObjectCount++;
                Variables.Money -= tempObj.MoneyPrice;
                Variables.Info -= tempObj.InfoPrice;
                Variables.Ideology -= tempObj.IdeologyPrice;

                tempObj.MoneyPrice *= tempObj.MoneyPriceMultiplier;
                tempObj.InfoPrice *= tempObj.InfoPriceMultiplier;
                tempObj.IdeologyPrice *= tempObj.IdeologyPriceMultiplier;

                UpdateMainCounters();
                UpdateSecondaryCounters();
                UpdateItemCounters();
                StatusTextBox.Text = "Ты купил " + tempObj.StatusName; ;
            }
            else
            {
                StatusTextBox.Text = "Недостаточно ресурсов!";
            }
        }

        private void BuyAction(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string objName = button.Tag as string;
            Action tempObj = ActionSelector(objName);

            if (Items.weapon.Count >= tempObj.WeaponPrice && Items.car.Count >= tempObj.CarPrice && Items.people.Count >= tempObj.PeoplePrice)
            {
                tempObj.Count++;
                Action.ObjectCount++;
                Item.ObjectCount -= tempObj.WeaponPrice - tempObj.CarPrice - tempObj.PeoplePrice;

                Items.weapon.Count -= tempObj.WeaponPrice;
                Items.car.Count -= tempObj.CarPrice;
                Items.people.Count -= tempObj.PeoplePrice;

                if (1 - Variables.rnd.NextDouble() < tempObj.Chance)
                {
                    StatusTextBox.Text = "Ты совершил неудачное " + tempObj.StatusName;
                }
                else
                {
                    Variables.MoneyBase += tempObj.MoneyBaseIncrement;
                    Variables.InfoBase += tempObj.InfoBaseIncrement;
                    Variables.IdeologyBase += tempObj.IdeologyBaseIncrement;

                    tempObj.WeaponPrice += tempObj.WeaponPriceIncrement;
                    tempObj.CarPrice += tempObj.CarPriceIncrement;
                    tempObj.PeoplePrice += tempObj.PeoplePriceIncrement;
                    tempObj.Chance += 0.05;

                    StatusTextBox.Text = "Ты совершил успешное " + tempObj.StatusName;
                }




                UpdateMainCounters();
                UpdateSecondaryCounters();
                UpdateItemCounters();
                UpdateActionCounters();

            }
            else
            {
                StatusTextBox.Text = "Недостаточно ресурсов!";
            }
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
