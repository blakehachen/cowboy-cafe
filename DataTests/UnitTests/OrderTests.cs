﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests
{
    public class OrderTests
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
        public void ShouldBeAbleToAddItems()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Add(item);
            Assert.Contains(item, order.Items);

        }

        [Fact]
        public void ShouldBeAbleToRemoveItems()
        {
            var order = new Order();
            var item = new MockOrderItem();
            order.Remove(item);
            Assert.DoesNotContain(item, order.Items);
        }

        [Fact]
        public void ShouldBeAbleToGetEnumerationOfItems()
        {
            var order = new Order();
            var item0 = new MockOrderItem();
            var item1 = new MockOrderItem();
            var item2 = new MockOrderItem();
            order.Add(item0);
            order.Add(item1);
            order.Add(item2);
            Assert.Collection(order.Items,
                item => Assert.Equal(item0, item),
                item => Assert.Equal(item1, item),
                item => Assert.Equal(item2, item));
        }

        [Theory]
        [InlineData(new double[] {1, 2, 3 })]
        [InlineData(new double[] {0, 0, 1, 0 })]
        [InlineData(new double[] { 199.34, 799.3 })]
        [InlineData(new double[] { 798 })]
        [InlineData(new double[] { })]
        [InlineData(new double[] { -5})]
        [InlineData(new double[] {-4, 10, 8.9 })]
        [InlineData(new double[] { 3.1345234262 })]
        [InlineData(new double[] { double.NaN })]
        public void SubtotalShouldBeTheSumOfItemPrices(double[] prices)
        {
            var order = new Order();
            double total = 0;
            foreach(var price in prices)
            {
                total += price;
                order.Add(new MockOrderItem()
                {
                    Price = price
                });
            }
            Assert.Equal(Math.Round(total, 2), Math.Round(order.Subtotal, 2));
        }

        [Theory]
        [InlineData("Price")]
        [InlineData("Items")]
        public void AddingAnItemShouldTriggerPropertyChangedForPrice(string propertyName)
        {
            var order = new Order();
            var item = new MockOrderItem();
            Assert.PropertyChanged(order, propertyName, () =>
            {
                order.Add(item);
            });
        }

        
        [Theory]
        [InlineData("Price")]
        [InlineData("Items")]
        public void RemovingAnItemShouldTriggerPropertyChangedForPrice(string propertyName)
        {
            var order = new Order();
            var item = new MockOrderItem();
            Assert.PropertyChanged(order, propertyName, () =>
            {
                order.Remove(item);
            });
        }

        [Fact]
        public void LastOrderNumberShouldBeLessThanOrderNumber()
        {
            var order1 = new Order();
            var order2 = new Order();
            var order3 = new Order();

            Assert.Equal(order1.OrderNumber,(uint) 1);
            Assert.Equal(order2.OrderNumber, (uint)2);
            Assert.Equal(order3.OrderNumber, (uint)3);
            
        }

        
        
    }
}
