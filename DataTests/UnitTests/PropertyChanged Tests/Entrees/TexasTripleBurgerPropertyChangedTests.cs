using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Entrees
{
    public class TexasTripleBurgerPropertyChangedTests
    {
        [Fact]
        public void TexasTripleBurgerShouldImplementINotifyPropertyChanged()
        {
            var burger = new TexasTripleBurger();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(burger);
        }

        [Theory]
        [InlineData("Bun")]
        [InlineData("SpecialInstructions")]
        public void ChangingBunShouldInvokePropertyChangedForBunandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
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
            var burger = new TexasTripleBurger();
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
            var burger = new TexasTripleBurger();
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
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Pickle = false;
            });
        }

        [Theory]
        [InlineData("Tomato")]
        [InlineData("SpecialInstructions")]
        public void ChangingTomatoShouldInvokePropertyChangedForTomatoandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Tomato = false;
            });
        }

        [Theory]
        [InlineData("Cheese")]
        [InlineData("SpecialInstructions")]
        public void ChangingCheeseShouldInvokePropertyChangedForCheeseandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Cheese = false;
            });
        }

        [Theory]
        [InlineData("Lettuce")]
        [InlineData("SpecialInstructions")]
        public void ChangingLettuceShouldInvokePropertyChangedForLettuceandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Lettuce = false;
            });
        }

        [Theory]
        [InlineData("Mayo")]
        [InlineData("SpecialInstructions")]
        public void ChangingMayoShouldInvokePropertyChangedForMayoandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Mayo = false;
            });
        }

        [Theory]
        [InlineData("Bacon")]
        [InlineData("SpecialInstructions")]
        public void ChangingBaconShouldInvokePropertyChangedForBaconandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Bacon = false;
            });
        }

        [Theory]
        [InlineData("Egg")]
        [InlineData("SpecialInstructions")]
        public void ChangingEggShouldInvokePropertyChangedForEggandSpecialInstructions(string propertyname)
        {
            var burger = new TexasTripleBurger();
            Assert.PropertyChanged(burger, propertyname, () =>
            {
                burger.Egg = false;
            });
        }
    }
}
