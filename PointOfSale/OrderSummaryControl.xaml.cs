/*

* Author: Blake Hachen

* Class name: OrderSummaryControl

* Purpose: This will be used to accept the data bindings of the order class. It will mainly be in charge of displaying attributes of the order class.

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
using CowboyCafe.PointOfSale;
using PointOfSale;
using PointOfSale.CustomizationScreens;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        
        /// <summary>
        /// Initializes OrderSummaryControl Window.
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// This function will be used to remove an Order Item from an order
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">event arguments</param>
        private void OnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            
            if (DataContext is Order data)
            {
                if(sender is Button button)
                {
                    data.Remove(button.DataContext as IOrderItem);
                }
            }
        }

        /// <summary>
        /// OrderSummaryControl.xaml.cs
        /// The helper method that will be in charge of switching the screen in the listItem_Click Event Handler. 
        /// </summary>
        /// <param name="item">item the user selects</param>
        /// <param name="screen">screen the user wants to switch to</param>
        private void CustomizeItem(IOrderItem item, FrameworkElement screen)
        {
            var orderControl = this.FindAncestor<OrderControl>();
            if (DataContext is Order)
            {
                if (screen != null)
                {
                    screen.DataContext = item;
                    orderControl?.SwapScreen(screen);
                }
                
            }
        }

        /// <summary>
        /// OrderSummaryControl.xaml.cs
        /// When a user clicks an item on a list the selected item will be casted to an IOrderItem and switched to the respective screen saved to that item.
        /// </summary>
        /// <param name="sender">Listbox</param>
        /// <param name="args">event args</param>
        private void listItem_Click(object sender, SelectionChangedEventArgs args)
        {
            //basic example in documentation uploaded to POS4 guidelines but instead of "IOrderItem" the example uses "ListBox" (lbi is null and an error occurs when an item is clicked)
            IOrderItem lbi = (sender as ListBox).SelectedItem as IOrderItem;
            CustomizeItem(lbi, lbi?.CustomizationScreen as FrameworkElement);
            (sender as ListBox).SelectedItem = null;
        }






    }
}
