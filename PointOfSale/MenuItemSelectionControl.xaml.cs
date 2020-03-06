/*

* Author: Blake Hachen

* Class name: MenuItemSelectionControl

* Purpose: This creates a base class that side classes can inherit methods from.

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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Initializes MenuItemSelection window
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
            
            
        }

        /// <summary>
        /// Adds Angry Chicken to the order
        /// </summary>
        private void AddAngryChickenButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new AngryChicken(), new AngryChickenCustomization());
        }

        /// <summary>
        /// Adds Cowpoke Chili to the order
        /// </summary>
        private void AddCowpokeChiliButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new CowpokeChili(), new CowpokeChiliCustomization());
        }

        /// <summary>
        /// Adds Rustler's Ribs to the order
        /// </summary>
        private void AddRustlersRibsButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new RustlersRibs(), new RustlersRibsCustomization());
        }

        /// <summary>
        /// Adds Pecos Pulled Pork to the order
        /// </summary>
        private void AddPecosPulledPorkButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new PecosPulledPork(), new PecosPulledPorkCustomization());
        }

        /// <summary>
        /// Adds Trail Bruger to the order
        /// </summary>
        private void AddTrailBurgerButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new TrailBurger(), new TrailBurgerCustomization());
        }

        /// <summary>
        /// Adds Dakota Double Burger to the order
        /// </summary>
        private void AddDakotaDoubleBurgerButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new DakotaDoubleBurger(), new DakotaDoubleBurgerCustomization());
        }

        /// <summary>
        /// Adds Texas Triple Bruger to the order
        /// </summary>
        private void AddTexasTripleBurgerButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new TexasTripleBurger(), new TexasTripleBurgerCustomization());
        }

        /// <summary>
        /// Adds Chili Cheese Fries to the order
        /// </summary>
        private void AddChiliCheeseFriesButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new ChiliCheeseFries(), new ChiliCheeseFriesCustomization());
        }

        /// <summary>
        /// Adds Corn Dodgers to the order
        /// </summary>
        private void AddCornDodgersButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new CornDodgers(), new CornDodgersCustomization());
        }

        /// <summary>
        /// Adds Pan De Campo to the order
        /// </summary>
        private void AddPanDeCampoButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new PanDeCampo(), new PanDeCampoCustomization());
        }

        /// <summary>
        /// Adds Baked Beans to the order
        /// </summary>
        private void AddBakedBeansButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new BakedBeans(), new BakedBeansCustomization());
        }

        /// <summary>
        /// Adds Jerked Soda to the order
        /// </summary>
        private void AddJerkedSodaButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new JerkedSoda(), new JerkedSodaCustomization());
        }

        /// <summary>
        /// Adds Texas Tea to the order
        /// </summary>
        private void AddTexasTeaButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new TexasTea(), new TexasTeaCustomization());
        }

        /// <summary>
        /// Adds Cowboy Coffee to the order
        /// </summary>
        private void AddCowboyCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new CowboyCoffee(), new CowboyCoffeeCustomization());
        }

        /// <summary>
        /// Adds Water to the order
        /// </summary>
        private void AddWaterButton_Click(object sender, RoutedEventArgs e)
        {
            AddAndCustomizeItem(new Water(), new WaterCustomization());
        }

        private void AddAndCustomizeItem(IOrderItem item, FrameworkElement screen)
        {
            var orderControl = this.FindAncestor<OrderControl>();
            if (DataContext is Order data)
            {
                data.Add(item);
                screen.DataContext = item;
                orderControl?.SwapScreen(screen);
            }
        }

    }
}
