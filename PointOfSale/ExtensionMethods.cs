/*

* Author: Blake Hachen

* Class name: ExtensionMethods

* Purpose: This class will be used for extensions that we will add to our user interface (Swapping screens)

*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CowboyCafe.PointOfSale
{
    /// <summary>
    /// Class representing extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// This method will be used to navigate customization screens
        /// </summary>
        public static T FindAncestor<T>(this DependencyObject element) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(element);
            
            if (parent == null) return null;

            if (parent is T) return parent as T;

            return parent.FindAncestor<T>();
            
        }
    }
}
