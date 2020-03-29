using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.ComponentModel;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Drinks
{
    public class CowboyCoffeePropertyChangedTests
    {
        [Fact]
        public void CowboyCoffeeShouldImplementINotifyPropertyChanged()
        {
            var coffee = new CowboyCoffee();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(coffee);
        }

        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForCowboyCoffee(string propertyname)
        {
            var coffee = new CowboyCoffee();
            Assert.PropertyChanged(coffee, propertyname, () =>
            {
                coffee.Size = Size.Medium;
            });
        }

        [Theory]
        [InlineData("Ice")]
        [InlineData("SpecialInstructions")]
        public void ChangingIceShouldInvokePropertyChangedForIceandSpecialInstructionsForCowboyCoffee(string propertyname)
        {
            var coffee = new CowboyCoffee();
            Assert.PropertyChanged(coffee, propertyname, () =>
            {
                coffee.Ice = true;
            });
        }

        [Theory]
        [InlineData("RoomForCream")]
        [InlineData("SpecialInstructions")]
        public void ChangingRoomForCreamShouldInvokePropertyChangedForIceandSpecialInstructionsForCowboyCoffee(string propertyname)
        {
            var coffee = new CowboyCoffee();
            Assert.PropertyChanged(coffee, propertyname, () =>
            {
                coffee.RoomForCream = true;
            });
        }

        [Fact]
        public void ChangingDecafShouldInvokePropertyChangedForDecafForCowboyCoffee()
        {
            var coffee = new CowboyCoffee();
            Assert.PropertyChanged(coffee, "Decaf", () =>
            {
                coffee.Decaf = true;
            });
        }
    }
}
