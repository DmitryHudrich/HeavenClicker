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
        private int i = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            Variables.Money += Variables.MoneyBase + Variables.rnd.NextDouble() * Variables.MoneyBonus;
            Variables.Info += Variables.InfoBase + Variables.rnd.NextDouble() * Variables.InfoBonus;
            Variables.Ideology += Variables.IdeologyBase + Variables.rnd.NextDouble() * Variables.IdeologyBonus;
            
            MoneyCounterTextBox.Text = "Money: " + Math.Round(Variables.Money, 2);
            InfoCounterTextBox.Text = "Info: " + Math.Round(Variables.Info, 2);
            IdeologyCounterTextBox.Text = "Ideology: " + Math.Round(Variables.Ideology, 2);
        }


    }
}
