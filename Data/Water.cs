/*

* Author: Blake Hachen

* Class name: Water

* Purpose: Inherits methods from the drink base class. This class represents the drink choice of water.

*/

using System;
using System.Collections.Generic;


namespace CowboyCafe.Data
{
    public class Water : Drink
    {
        private bool lemon = false;
        /// <summary>
        /// If the water has lemon
        /// </summary>
        public bool Lemon
        {
            get { return lemon; }
            set { lemon = value; }
        }

        /// <summary>
        /// The price of the water
        /// </summary>
        public override double Price
        {
            get
            {
                return 0.12;
            }
        }

        /// <summary>
        /// The calories of the water
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Special instructions for preparing the water
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();
                if (lemon) instructions.Add("Add Lemon");
                if (!Ice) instructions.Add("Hold Ice");
                return instructions;
            }
        }
    }
}
