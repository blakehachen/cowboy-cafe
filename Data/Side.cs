/*

* Author: Blake Hachen

* Class name: Side

* Purpose: This creates a base class that side classes can inherit methods from.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CowboyCafe.Data
{
    /// <summary>
    /// A base class representing a side
    /// </summary>
    public abstract class Side : IOrderItem, INotifyPropertyChanged
    {

        public object CustomizationScreen { get; set; }

        public string Category { get; set; } = "Side";

        /// <summary>
        /// Event handler used to check if property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private Size size = Size.Small;
        /// <summary>
        /// Gets the size of the entree
        /// </summary>
        public virtual Size Size
        {
            get { return size; }
            set
            {
                size = value;
                NotifyIfPropertyChanges("Size");
            }
        }

        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the entree
        /// </summary>
        public abstract uint Calories { get; }

        public List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();
                return instructions;
            }
        }

        /// <summary>
        /// This method will be used to check a string that correlates to the properties of the order items and change it accordingly
        /// </summary>
        protected void NotifyIfPropertyChanges(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }
    }
}
