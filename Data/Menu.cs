using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CowboyCafe.Data
{
    public static class Menu
    {
        private static List<IOrderItem> entrees = new List<IOrderItem>();
        private static List<IOrderItem> sides = new List<IOrderItem>();
        private static List<IOrderItem> drinks = new List<IOrderItem>();
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
        /// String array of Item Categories/Types
        /// </summary>
        public static string[] ItemTypes
        {
            get => new string[]
            {
                "Entree",
                "Side",
                "Drink"
            };
        }

        /// <summary>
        /// Filters Collection by search terms
        /// </summary>
        /// <param name="items">Collection to filter</param>
        /// <param name="terms">terms used to determine the new collection</param>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> items, string terms)
        {
           
            if (terms == null) return items;

            if (terms != null)
            {
                items = items.Where(
                    item => item.ToString() != null && 
                    item.ToString().Contains(terms, StringComparison.CurrentCultureIgnoreCase )
                    );
            }

            return items;
        }

        /// <summary>
        /// Filters collection by item category (Entree, Drink, Side)
        /// </summary>
        /// <param name="items">Collection to filter</param>
        /// <param name="types">Collection of Item Types</param>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> items, IEnumerable<string> types)
        {
            if (types == null || types.Count() == 0) return items;
            
           
            if(types != null && types.Count() != 0)
            {
                items = items.Where(
                    item => item.Category != null && types.Contains(item.Category)
                    );
            }
            
            return items;
            
        }

        /// <summary>
        /// Filters collection by calories
        /// </summary>
        /// <param name="items">collection to filter</param>
        /// <param name="min">calorie min criteria</param>
        /// <param name="max">calorie max criteria</param>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> items, int? min, int? max)
        {
            if (min == null && max == null) return items;
            
            if (min != null && max != null)
            {
                items = items.Where(
                    item => item.Calories >= min && item.Calories <= max
                    );
            }
            else if (min == null && max != null)
            {
                items = items.Where(
                    item => item.Calories <= max
                    );
            }
            else
            {
                items = items.Where(
                    item => item.Calories >= min
                    );
            }

            return items;
        }
        /// <summary>
        /// Filters Collection based on min and max parameters
        /// </summary>
        /// <param name="items">Collection to filter</param>
        /// <param name="min">price min criteria</param>
        /// <param name="max">price max criteria</param>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> items, double? min, double? max)
        {
            if (min == null && max == null) return items;

            if (min != null && max != null)
            {
                items = items.Where(
                    item => item.Price >= min && item.Price <= max
                    );
            }
            else if (min == null && max != null)
            {
                items = items.Where(
                    item => item.Price <= max
                    );
            }
            else
            {
                items = items.Where(
                    item => item.Price >= min
                    );
            }

            return items;
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
