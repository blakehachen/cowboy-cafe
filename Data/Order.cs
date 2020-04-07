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
        public double Total => Math.Round(Subtotal * 1.16, 2);


        public double Subtotal
        {
            get
            {
                double total = 0.0;
                foreach (IOrderItem item in items)
                {
                    total += item.Price;
                }
                return Math.Round(total, 2);
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
        /// Gets the current OrderNumber for the transaction
        /// </summary>
        public static uint CurrentOrderNumber
        {
            get
            {
                return lastOrderNumber;
            }
        }

        public string Receipt
        {
            get
            {


                StringBuilder sb = new StringBuilder();

                sb.Append("Order# " + CurrentOrderNumber.ToString() + "  ");
                sb.Append(DateTime.Now.ToString() + "\n");

                foreach (IOrderItem item in Items)
                {
                    sb.Append(item.ToString() + "  ");
                    sb.Append(item.Price.ToString() + "\n");
                    foreach (string i in item.SpecialInstructions)
                    {
                        sb.Append("  " + i.ToString() + "\n");
                    }
                }
                sb.Append("Subtotal: " + Subtotal.ToString() + "\n");
                sb.Append("Total After 16% Sales Tax: " + Total.ToString() + "\n");
                if (PaymentType) sb.Append("Payment Type: Credit");
                else
                {
                    sb.Append("Total paid: " + CashPaid.ToString() + "\n");
                    sb.Append("Change: " + Change.ToString() + "\n");
                    sb.Append("Payment Type: Cash");
                }
                



                return sb.ToString() + "\n\n";
            }
        }

        private bool cash = false;
        /// <summary>
        /// Represents whether the payment type used for the order is a cash payment or credit payment.
        /// </summary>
        public bool PaymentType
        {
            get
            {
                return cash;
            }

            set
            {
                cash = value;
            }
        }

        /// <summary>
        /// Used to grab cash paid from cashregistermodelview.
        /// </summary>
        public double CashPaid { get; set; }

        /// <summary>
        /// Used to grab change dispersed from cashregistermodelview
        /// </summary>
        public double Change { get; set; }
        


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


            if (item is INotifyPropertyChanged pcitem)
            {
                pcitem.PropertyChanged += OnItemChanged;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
        }

        /// <summary>
        /// This method will be used to check and see if the price property is changed then it will change the subtotal as needed.
        /// </summary>
        private void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            if (e.PropertyName == "Size") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal")); PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
        }


    }
}
