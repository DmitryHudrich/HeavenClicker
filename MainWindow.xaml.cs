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
        InventoryObject weapon = new InventoryObject("weapon")
        {
            MoneyPrice = 5,
            InfoPrice = 5,
            MoneyPriceMultiplier = 1.2,
            InfoPriceMultiplier = 1.5
        };

        InventoryObject car = new InventoryObject("car")
        {
            MoneyPrice = 5,
            InfoPrice = 5,
            MoneyPriceMultiplier = 1.2,
            InfoPriceMultiplier = 1.5
        };

        InventoryObject people = new InventoryObject("people")
        {
            MoneyPrice = 5,
            InfoPrice = 5,
            MoneyPriceMultiplier = 1.2,
            InfoPriceMultiplier = 1.5
        };


        public void UpdateMainCounters()
        {
            MoneyCounterTextBox.Text = "Деньги: " + Math.Round(Variables.Money, 2);
            InfoCounterTextBox.Text = "Информация: " + Math.Round(Variables.Info, 2);
            IdeologyCounterTextBox.Text = "Идеология: " + Math.Round(Variables.Ideology, 2);
        }

        public void UpdateSecondaryCounters()
        {
            WeaponCounterTextBox.Text = "Пушек: " + Variables.Weapons;
            CarCounterTextBox.Text = "Машин: " + Variables.Cars;
            PeopleCounterTextBox.Text = "Людей: " + Variables.People;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            Variables.Money += Variables.MoneyBase + Variables.rnd.NextDouble() * Variables.MoneyBonus;
            Variables.Info += Variables.InfoBase + Variables.rnd.NextDouble() * Variables.InfoBonus;
            Variables.Ideology += Variables.IdeologyBase + Variables.rnd.NextDouble() * Variables.IdeologyBonus;

            UpdateMainCounters();
        }

        private void BuyItem(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string objName = button.Tag as string;


            

        }
    }
}
