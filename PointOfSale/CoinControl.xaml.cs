﻿/*

* Author: Blake Hachen
* Co-Author: Nathan Bean

* Class name: CoinControl.xaml.cs

* Purpose: Represents a usercontrol for each coin denomination.

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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CoinControl.xaml
    /// </summary>
    public partial class CoinControl : UserControl
    {
        /// <summary>
        /// The DependencyProperty for the DenominationProperty
        /// </summary>
        public static readonly DependencyProperty DenominationProperty =
            DependencyProperty.Register(
                    "Denomination",
                    typeof(Coins),
                    typeof(CoinControl),
                    new PropertyMetadata(Coins.Penny)
                );

        /// <summary>
        /// Denomination this control will display or modify
        /// </summary>
        public Coins Denomination
        {
            get
            {
                return (Coins)GetValue(DenominationProperty);

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
                typeof(CoinControl),
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

        
        public CoinControl()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Updates quantity of denomination on the increase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnIncreaseClicked(object sender, RoutedEventArgs e)
        {
            Quantity++; 
        }

        /// <summary>
        /// Updates Quantity of denomination on decrease.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDecreaseClicked(object sender, RoutedEventArgs e)
        {
            Quantity--;
        }
    }
}