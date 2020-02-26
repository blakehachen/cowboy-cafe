using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class Order : INotifyPropertyChanged
    {
        private uint lastOrderNumber;

        private List<IOrderItem> items = new List<IOrderItem>();

        public IEnumerable<IOrderItem> Items => throw new NotImplementedException();
      

        public double Subtotal => 0;

        public uint OrderNumber { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add(IOrderItem item)
        {
            items.Add(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
        }

        public void Remove(IOrderItem item)
        {
            items.Remove(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
        }
    }
}
