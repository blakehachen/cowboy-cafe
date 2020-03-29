/*

* Author: Blake Hachen

* Class name: IOrderItem <<interface>>

* Purpose: Interface that represents an item on the menu. Gets the price and special instructions for each entree, side, and drink

*/
using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Interface representing an Order Item
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// Gets the price of the order item
        /// </summary>
        double Price { get; }
        /// <summary>
        /// Gets the special instrictions for preparing the order item
        /// </summary>
        List<string> SpecialInstructions { get; }

                
        object CustomizationScreen { get; set; }
    }
}
