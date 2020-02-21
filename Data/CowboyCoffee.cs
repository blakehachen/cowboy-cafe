/*

* Author: Blake Hachen

* Class name: CowboyCoffee

* Purpose: Inherits methods from the drink base class. This class represents the drink choice of cowboy coffee.

*/

using System;
using System.Collections.Generic;


namespace CowboyCafe.Data
{
    /// <summary>
    /// Class representing drink choice of cowboy coffee
    /// </summary>
    public class CowboyCoffee : Drink
    {
        private bool roomforcream = false;
        /// <summary>
        /// If there is room for cream
        /// </summary>
        public bool RoomForCream 
        {
            get { return roomforcream; }
            set { roomforcream = value; }
        }

        private bool decaf = false;
        /// <summary>
        /// If the coffee is decaf
        /// </summary>
        public bool Decaf 
        { 
            get { return decaf; }
            set { decaf = value; }
        
        }
        
        private bool ice = false;
        /// <summary>
        /// If there is ice
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { ice = value; }
        }

        /// <summary>
        /// The price of the coffee
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                        return 1.60;
                    case Size.Medium:
                        return 1.10;
                    case Size.Small:
                        return 0.60;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The calories of the coffee
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                        return 7;
                    case Size.Medium:
                        return 5;
                    case Size.Small:
                        return 3;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the coffee
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();
                if (ice) instructions.Add("Add Ice");
                if (roomforcream) instructions.Add("Room for Cream");
                return instructions;
            }
        }

        /// <summary>
        /// Readable string representing drink cowboy coffee
        /// </summary>
        public override string ToString()
        {
            switch (Size)
            {
                case Size.Large:
                    if (Decaf) return "Large Decaf Cowboy Coffee";
                    return "Large Cowboy Coffee";
                case Size.Medium:
                    if (Decaf) return "Medium Decaf Cowboy Coffee";
                    return "Medium Cowboy Coffee";
                case Size.Small:
                    if (Decaf) return "Small Decaf Cowboy Coffee";
                    return "Small Cowboy Coffee";
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
