using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DimaClicker
{
    class UpgradeButton : Button
    {
        private bool isInitialClick = true;
        private string initialContent;

        public static readonly DependencyProperty UpgradePriceProperty =
        DependencyProperty.Register("UpgradePrice", typeof(int), typeof(UpgradeButton));

        public static readonly DependencyProperty ClickForceProperty =
        DependencyProperty.Register("ClickForce", typeof(int), typeof(UpgradeButton));

        public static readonly DependencyProperty ObjectNameProperty =
        DependencyProperty.Register("ObjectName", typeof(string), typeof(UpgradeButton));

        public int UpgradePrice
        {
            get { return (int)GetValue(UpgradePriceProperty); }
            set { SetValue(UpgradePriceProperty, value); }
        }

        public int ObjectName
        {
            get { return (int)GetValue(ObjectNameProperty); }
            set { SetValue(ObjectNameProperty, value); }
        }

        public int ClickPower
        {
            get { return (int)GetValue(ClickForceProperty); }
            set { SetValue(ClickForceProperty, value); }
        }

        public void UpdateTextContent()
        {
            if (isInitialClick)
            {
                initialContent = Content?.ToString(); // Сохраняем исходное содержимое кнопки
                isInitialClick = false;
            }

            if (!string.IsNullOrEmpty(initialContent))
            {
                // Если есть исходное содержимое, добавляем Upgrade Price к исходному содержимому
                Content = $"{initialContent} - Upgrade Price: {UpgradePrice}";
            }
            else
            {
                // Если исходное содержимое пустое, просто отображаем Upgrade Price
                Content = $"Upgrade Price: {UpgradePrice}";
            }
        }

        public void UpdateContent()
        {
            ClickPower++;
            UpgradePrice = (int)(UpgradePrice * 1.5);

            UpdateTextContent();

        }
    }
}
