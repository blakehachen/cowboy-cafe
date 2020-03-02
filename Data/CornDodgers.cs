/*

* Author: Blake Hachen

* Class name: CornDodgers

* Purpose: Inherits methods from the side base class. This class represents the Corn Dodgers side.

*/
using System;
using System.Collections.Generic;


namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Corn Dodgers side
    /// </summary>
    public class CornDodgers : Side
    {
        /// <summary>
        /// The calories of the Corn Dodgers based on the size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                        return 717;
                    case Size.Medium:
                        return 685;
                    case Size.Small:
                        return 512;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the Corn Dodgers based on the size
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                        return 1.99;
                    case Size.Medium:
                        return 1.79;
                    case Size.Small:
                        return 1.59;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Readable string representing side corn dodgers
        /// </summary>
        public override string ToString()
        {
            switch (Size)
            {
                case Size.Large:
                    return "Large Corn Dodgers";
                case Size.Medium:
                    return "Medium Corn Dodgers";
                case Size.Small:
                    return "Small Corn Dodgers";
                default:
                    throw new NotImplementedException();
            }
        }

        
    }
}
