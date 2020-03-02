/*

* Author: Blake Hachen

* Class name: Entree

* Purpose: A base class for other entree classes to inherit from.

*/
using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A base class representing an entree
    /// </summary>
    public abstract class Entree : IOrderItem
    {
        /// <summary>
        /// Gets the price of an entree
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of an entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Gets the Special Instructions of an entree
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }

    }
}
