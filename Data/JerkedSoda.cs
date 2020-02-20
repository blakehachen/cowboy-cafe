/*

* Author: Blake Hachen

* Class name: JerkedSoda

* Purpose: Inherits methods from the drink base class. This class represents the drink choice of Jerked Soda.

*/

using System;
using System.Collections.Generic;


namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the drink choice of jerked soda
    /// </summary>
    public class JerkedSoda : Drink
    {
        
        /// <summary>
        /// The flavor of the soda
        /// </summary>
        public SodaFlavor Flavor { get; set; }

        /// <summary>
        /// The price of the soda
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case (Size.Large):
                        return 2.59;
                    case (Size.Medium):
                        return 2.10;
                    case (Size.Small):
                        return 1.59;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The calories of the soda
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case (Size.Large):
                        return 198;
                    case (Size.Medium):
                        return 146;
                    case (Size.Small):
                        return 110;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Special instructions for preparing the soda
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();
                if (!Ice) instructions.Add("Hold Ice");
                return instructions;
            }
        }

        public override string ToString()
        {
            return "Jerked Soda";
        }
    }
}
