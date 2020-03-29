using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Entrees
{
    public class TrailBurgerPropertyChangedTests
    {
        [Fact]
        public void TexasTripleBurgerShouldImplementINotifyPropertyChanged()
        {
            var burger = new TrailBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(burger);
        }

        [Theory]
        [InlineData("Bun")]
        [InlineData("SpecialInstructions")]
        public void ChangingBunShouldInvokePropertyChangedForBunandSpecialInstructions(string propertyname)
        {
            var burger = new TrailBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Bun = false;
            });
        }

        [Theory]
        [InlineData("Ketchup")]
        [InlineData("SpecialInstructions")]
        public void ChangingKetchupShouldInvokePropertyChangedForKetchupandSpecialInstructions(string propertyname)
        {
            var burger = new TrailBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Ketchup = false;
            });
        }

        [Theory]
        [InlineData("Mustard")]
        [InlineData("SpecialInstructions")]
        public void ChangingMustardShouldInvokePropertyChangedForMustardandSpecialInstructions(string propertyname)
        {
            var burger = new TrailBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Mustard = false;
            });
        }

        [Theory]
        [InlineData("Pickle")]
        [InlineData("SpecialInstructions")]
        public void ChangingPickleShouldInvokePropertyChangedForPickleandSpecialInstructions(string propertyname)
        {
            var burger = new TrailBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Pickle = false;
            });
        }

        [Theory]
        [InlineData("Cheese")]
        [InlineData("SpecialInstructions")]
        public void ChangingCheeseShouldInvokePropertyChangedForCheeseandSpecialInstructions(string propertyname)
        {
            var burger = new TrailBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Cheese = false;
            });
        }
    }
}
