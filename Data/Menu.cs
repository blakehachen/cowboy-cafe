using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public static class Menu
    {
        private static List<Entree> entrees = new List<Entree>();
        private static List<Side> sides = new List<Side>();
        private static List<Drink> drinks = new List<Drink>();
        private static List<IOrderItem> completemenu = new List<IOrderItem>();
        /// <summary>
        /// Loads all entrees, sides and drinks into their respective lists
        /// </summary>
        static Menu()
        {
            entrees.Add(new AngryChicken());
            entrees.Add(new RustlersRibs());
            entrees.Add(new PecosPulledPork());
            entrees.Add(new CowpokeChili());
            entrees.Add(new TrailBurger());
            entrees.Add(new DakotaDoubleBurger());
            entrees.Add(new TexasTripleBurger());
            sides.Add(new ChiliCheeseFries());
            sides.Add(new CornDodgers());
            sides.Add(new PanDeCampo());
            sides.Add(new BakedBeans());
            drinks.Add(new JerkedSoda());
            drinks.Add(new TexasTea());
            drinks.Add(new CowboyCoffee());
            drinks.Add(new Water());
            completemenu.Add(new AngryChicken());
            completemenu.Add(new RustlersRibs());
            completemenu.Add(new PecosPulledPork());
            completemenu.Add(new CowpokeChili());
            completemenu.Add(new TrailBurger());
            completemenu.Add(new DakotaDoubleBurger());
            completemenu.Add(new TexasTripleBurger());
            completemenu.Add(new ChiliCheeseFries());
            completemenu.Add(new CornDodgers());
            completemenu.Add(new PanDeCampo());
            completemenu.Add(new BakedBeans());
            completemenu.Add(new JerkedSoda());
            completemenu.Add(new TexasTea());
            completemenu.Add(new CowboyCoffee());
            completemenu.Add(new Water());

        }
        
        
        
        /// <summary>
        /// Gets all the entrees in the entree list
        /// </summary>
        public static IEnumerable<IOrderItem> Entrees => entrees;
        /// <summary>
        /// Gets all the sides in the side list
        /// </summary>
        public static IEnumerable<IOrderItem> Sides => sides;
        /// <summary>
        /// Gets all the drinks in the drink list
        /// </summary>
        public static IEnumerable<IOrderItem> Drinks => drinks;
        /// <summary>
        /// Gets all the menu items in the completemenu list
        /// </summary>
        public static IEnumerable<IOrderItem> CompleteMenu => completemenu;
        
        
        
    }
}
