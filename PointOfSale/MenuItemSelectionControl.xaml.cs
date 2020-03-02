using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CowboyCafe.Data;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        
        public MenuItemSelectionControl()
        {
            InitializeComponent();
            
            
        }

        private void AddAngryChickenButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is Order data)
            {
                if(sender is Button button)
                {
                    data.Add(new AngryChicken());
                }
                
            }
        }

        private void AddCowpokeChiliButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRustlersRibsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPecosPulledPorkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTrailBurgerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddDakotaDoubleBurgerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTexasTripleBurgerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddChiliCheeseFriesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCornDodgersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPanDeCampoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBakedBeansButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddJerkedSodaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTexasTeaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCowboyCoffeeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddWaterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
