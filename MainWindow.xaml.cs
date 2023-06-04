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

        private void BuyWeapon(object sender, RoutedEventArgs e)
        {
            if(Variables.Money >= Variables.WeaponMoneyPrice && Variables.Info >= Variables.WeaponInfoPrice)
            {
                Variables.Money -= Variables.WeaponMoneyPrice;
                Variables.Info -= Variables.WeaponInfoPrice;

                Variables.Weapons++;

                UpdateMainCounters();
                UpdateSecondaryCounters();

                StatusTextBox.Text = "Ты купил пушку!";
            }
            else
            {
                StatusTextBox.Text = "Недостаточно ресурсов";
            }
        }

        private void BuyCar(object sender, RoutedEventArgs e)
        {

        }

        private void BuyPeople(object sender, RoutedEventArgs e)
        {

        }
    }
}
