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
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
            
           
        }

        private void AddCowpokeChiliButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new CowpokeChili());
        }

        private void AddRustlersRibsButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new RustlersRibs());
        }

        private void AddPecosPulledPorkButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new PecosPulledPork());
        }

        private void AddAngryChickenButton_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Items.Add(new AngryChicken());
        }
    }
}
