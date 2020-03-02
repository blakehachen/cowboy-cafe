/*

* Author: Blake Hachen

* Class name: Drink

* Purpose: The base class for all drinks on the menu.

*/

using System;
using System.Collections.Generic;


namespace CowboyCafe.Data
{
    /// <summary>
    /// Class representing the generic drink properties
    /// </summary>
    public abstract class Drink : IOrderItem
    {
        private bool ice = true;
        /// <summary>
        /// If the drink has ice
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { ice = value; }
        }

        private Size size = Size.Small;
        /// <summary>
        /// Size of the drink
        /// </summary>
        public virtual Size Size
        {
            get { return size; }
            set { size = value; }
        }
        
        /// <summary>
        /// Price of the drink
        /// </summary>
        public abstract double Price { get; }
        
        /// <summary>
        /// Calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for preparing the drink
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
