﻿/*

* Author: Blake Hachen

* Class name: Baked Beans

* Purpose: Inherits methods from the side base class. This class represents the Baked Beans side.

*/

using System;
using System.Collections.Generic;


namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Baked Beans side
    /// </summary>
    public class BakedBeans : Side
    {
        /// <summary>
        /// The calories of the Baked Beans depending on the size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Large:
                       //NotifyIfPropertyChanges("Calories");
                        return 410;
                    case Size.Medium:
                        //NotifyIfPropertyChanges("Calories");
                        return 378;
                    case Size.Small:
                        //NotifyIfPropertyChanges("Calories");
                        return 312;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The price of the Baked Beans depending on the size
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
        /// Readable string representing side baked Beans
        /// </summary>
        public override string ToString()
        {
            switch (Size)
            {
                case Size.Large:
                    return "Large Baked Beans";
                case Size.Medium:
                    return "Medium Baked Beans";
                case Size.Small:
                    return "Small Baked Beans";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
