using System;
using System.Collections.Generic;
using System.Text;
using CowboyCafe.Data;
using Xunit;
using System.ComponentModel;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests
{
    public class OrderPropertyChangedTests
    {
        public class MockOrderItem : IOrderItem
        {
            public double Price { get; set; }

            public List<string> SpecialInstructions { get; set; } = new List<string>();

            object IOrderItem.CustomizationScreen { get; set; }
            public string Category { get; set; }

            public uint Calories { get; }
        }

        [Fact]
        public void OrderShouldImplementINotifyPropertyChanged()
        {
            var order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        [Theory]
        [InlineData("Items")]
        [InlineData("Price")]
        [InlineData("Subtotal")]
        public void AddingOrderItemShouldInvokePropertyChangedForItemsPriceAndSubtotal(string propertyname)
        {
            var order = new Order();
            var item = new MockOrderItem();
            Assert.PropertyChanged(order, propertyname, () =>
            {
                order.Add(item);
            });
        }

        [Theory]
        [InlineData("Items")]
        [InlineData("Price")]
        [InlineData("Subtotal")]
        public void RemovingOrderItemShouldInvokePropertyChangedForItemsPriceAndSubtotal(string propertyname)
        {
            var order = new Order();
            var item = new MockOrderItem();
            Assert.PropertyChanged(order, propertyname, () =>
            {
                order.Remove(item);
            });
        }

    }
}
