/*

* Author: Blake Hachen

* Class name: OrderControl.xaml.cs

* Purpose: Uses the Data project to matinpulate the Order Control interface.

*/
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
        /// <summary>
        /// Initializes Windows Presentation Form
        /// </summary>
        public OrderControl()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Cancels the order by setting the data context of the databinding to a new order instance.
        /// </summary>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is Order)
            {
                DataContext = new Order();
            }
        }

        /// <summary>
        /// Cancels the order by setting the data context of the databinding to a new order instance. Further implementation may be needed.
        /// </summary>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is Order)
            {
                DataContext = new Order();
            }
        }
    }
}
