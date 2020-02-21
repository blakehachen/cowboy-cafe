/*

* Author: Blake Hachen

* Class name: TexasTea

* Purpose: Inherits methods from the drink base class. This class represents the drink choice of Texas Tea.

*/

using System;
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Class representing drink choice of texas tea
    /// </summary>
    public class TexasTea : Drink
    {
        private bool sweet = true;
        /// <summary>
        /// If the tea is sweet
        /// </summary>
        public bool Sweet
        {
            get { return sweet; }
            set { sweet = value; }
        }

        private bool lemon = false;
        /// <summary>
        /// If the tea has lemon
        /// </summary>
        public bool Lemon
        {
            get { return lemon; }
            set { lemon = value; }
        }

        /// <summary>
        /// The price of the tea
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                        return 2.00;
                    case Size.Medium:
                        return 1.50;
                    case Size.Small:
                        return 1.00;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The calories of the tea
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                        if(sweet) return 36;
                        return 18;
                    case Size.Medium:
                        if (sweet) return 22;
                        return 11;
                    case Size.Small:
                        if (sweet) return 10;
                        return 5;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Special instructions for preparing the tea
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();
                if (!Ice) instructions.Add("Hold Ice");
                if (lemon) instructions.Add("Add Lemon");
                return instructions;
            }
        }

        /// <summary>
        /// Readable string representing drink texas tea
        /// </summary>
        public override string ToString()
        {
            switch (Size)
            {
                case Size.Large:
                    if (Sweet) return "Large Texas Sweet Tea";
                    return "Large Texas Plain Tea";
                case Size.Medium:
                    if (Sweet) return "Medium Texas Sweet Tea";
                    return "Medium Texas Plain Tea";
                case Size.Small:
                    if (Sweet) return "Small Texas Sweet Tea";
                    return "Small Texas Plain Tea";
                default:
                    throw new NotImplementedException();
            }
        }

    }
}

