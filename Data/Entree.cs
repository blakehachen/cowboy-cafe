/*

* Author: Blake Hachen

* Class name: Entree

* Purpose: A base class for other entree classes to inherit from.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A base class representing an entree
    /// </summary>
    public abstract class Entree : IOrderItem, INotifyPropertyChanged
    {

        public object CustomizationScreen { get; set; }

        /// <summary>
        /// Event handler used to check if property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
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


        public string Category { get; set; } = "Entree";
        /// <summary>
        /// This method will be used to check a string that correlates to the properties of the order items and change it accordingly
        /// </summary>
        protected void NotifyIfPropertyChanges(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }

    }
}
