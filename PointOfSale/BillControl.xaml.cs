/*

* Author: Blake Hachen
* Co-Author: Nathan Bean

* Class name: CoinControl.xaml.cs

* Purpose: Represents a usercontrol for each bill denomination.

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
using CashRegister;
using PointOfSale;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for BillControl.xaml
    /// </summary>
    public partial class BillControl : UserControl
    {
        /// <summary>
        /// The DependencyProperty for the DenominationProperty
        /// </summary>
        public static readonly DependencyProperty DenominationProperty =
            DependencyProperty.Register(
                    "Denomination",
                    typeof(Bills),
                    typeof(BillControl),
                    new PropertyMetadata(Bills.One)
                );

        /// <summary>
        /// Denomination this control will display or modify
        /// </summary>
        public Bills Denomination
        {
            get
            {
                return (Bills)GetValue(DenominationProperty);

            }
            set { SetValue(DenominationProperty, value); }
        }

        /// <summary>
        /// The DependencyProperty for the Quantity Property
        /// </summary>
        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register(
                "Quantity",
                typeof(int),
                typeof(BillControl),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                );

        /// <summary>
        /// Quantity this control will display or modify.
        /// </summary>
        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        public BillControl()
        {
            InitializeComponent();
          
        }

        /// <summary>
        /// Updates quantity of denomination on increase click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDecreaseClicked(object sender, RoutedEventArgs e)
        {
            Quantity--;
        }

        /// <summary>
        /// Updates quantity of denomination don decrease click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIncreaseClicked(object sender, RoutedEventArgs e)
        {
            Quantity++;
        }
    }
}
