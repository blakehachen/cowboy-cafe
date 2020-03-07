/*

* Author: Blake Hachen

* Class name: Drink

* Purpose: The base class for all drinks on the menu.

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CowboyCafe.Data
{
    /// <summary>
    /// Class representing the generic drink properties
    /// </summary>
    public abstract class Drink : IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// Event handler used to check if property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private bool ice = true;
        /// <summary>
        /// If the drink has ice
        /// </summary>
        public virtual bool Ice 
        {
            get { return ice; }
            set 
            { 
                ice = value;
                NotifyIfPropertyChanges("Ice");
            }
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
