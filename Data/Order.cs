/*

* Author: Blake Hachen

* Class name: Order

* Purpose: A class that represents the attributes of an order. We will bind these properties to items within the UI.

*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// Previous order number. On initialization it will be 1.
        /// </summary>
        private static uint lastOrderNumber;

        
        private List<IOrderItem> items = new List<IOrderItem>();
        /// <summary>
        /// List representing items added to the order.
        /// </summary>
        public IEnumerable<IOrderItem> Items
        {
            get
            {
                return items.ToArray();
            }
        }
        
      
        /// <summary>
        /// Gets the subtotal of the order.
        /// </summary>
        public double Subtotal
        {
            get
            {
                double total = 0.0;
                foreach(IOrderItem item in items)
                {
                    total += item.Price;
                }
                return total;
            }
        }

        /// <summary>
        /// Gets the order number for the current Order instance.
        /// </summary>
        public uint OrderNumber
        {
            get
            {
                lastOrderNumber++;
                return lastOrderNumber;
            }
        }

        /// <summary>
        /// Event handler that will be in charge of connecting our Order class with our user interface to utilize Data Binding.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method will be used to add order items to the order as well as invoke any changes on the properties within the class. This will be useful for data binding.
        /// </summary>
        /// <param name="item">Order Item to add</param>
        public void Add(IOrderItem item)
        {
            items.Add(item);
            
            
            if (item is INotifyPropertyChanged pcitem) {
                pcitem.PropertyChanged += OnItemChanged;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
        }

        /// <summary>
        /// This method will be used to remove order items from the order as well as invoke any changes on the properties within the class.
        /// </summary>
        /// <param name="item">Order Item to remove</param>
        public void Remove(IOrderItem item)
        {
            items.Remove(item);
            
           
            if (item is INotifyPropertyChanged pcitem)
            {
                pcitem.PropertyChanged -= OnItemChanged;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
        }

        /// <summary>
        /// This method will be used to check and see if the price property is changed then it will change the subtotal as needed.
        /// </summary>
        private void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            if(e.PropertyName == "Price") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
        }
    }
}
