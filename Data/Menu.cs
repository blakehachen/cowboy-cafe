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
        
        
        public static string[] ItemTypes
        {
            get => new string[]
            {
                "Entree",
                "Side",
                "Drink"
            };
        }

        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> items, string terms)
        {
            
            List<IOrderItem> results = new List<IOrderItem>();

            if (terms == null) return items;

            foreach(IOrderItem item in items)
            {
                if (item.ToString().Contains(terms, StringComparison.InvariantCultureIgnoreCase))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> items, IEnumerable<string> types)
        {
            if (types == null || types.Count() == 0) return items;
            List<IOrderItem> results = new List<IOrderItem>();
            foreach(IOrderItem item in items)
            {
                if(item.Category != null && types.Contains(item.Category) )
                {
                    results.Add(item);
                }
            }
            return results;
            
        }

        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> items, uint? min, uint? max)
        {
            if (min == null && max == null) return items;
            List<IOrderItem> results = new List<IOrderItem>();

            if(min == null)
            {
                foreach(IOrderItem item in items)
                {
                    if (item.Calories <= max) results.Add(item);
                }
                return results;
            }

            if(max == null)
            {
                foreach(IOrderItem item in items)
                {
                    if (item.Calories >= min) results.Add(item);
                }
                return results;
            }
            foreach(IOrderItem item in items)
            {
                if(item.Calories >= min && item.Calories <= max)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> items, double? min, double? max)
        {
            if (min == null && max == null) return items;
            List<IOrderItem> results = new List<IOrderItem>();

            if (min == null)
            {
                foreach (IOrderItem item in items)
                {
                    if (item.Price <= max) results.Add(item);
                }
                return results;
            }

            if (max == null)
            {
                foreach (IOrderItem item in items)
                {
                    if (item.Price >= min) results.Add(item);
                }
                return results;
            }
            foreach (IOrderItem item in items)
            {
                if (item.Price >= min && item.Price <= max)
                {
                    results.Add(item);
                }
            }
            return results;
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
