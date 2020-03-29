using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Drinks
{
    public class JerkedSodaPropertyChangedTests
    {
        [Fact]
        public void JerkedSodaShouldImplementINotifyPropertyChanged()
        {
            var soda = new JerkedSoda();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(soda);
        }

        [Fact]
        public void ChangingFlavorShouldInvokePropertyChangedForFlavorForJerkedSoda()
        {
            var soda = new JerkedSoda();
            Assert.PropertyChanged(soda, "Flavor", () =>
            {
                soda.Flavor = SodaFlavor.CreamSoda;
            });
        }

        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForJerkedSoda(string propertyname)
        {
            var soda = new JerkedSoda();
            Assert.PropertyChanged(soda, propertyname, () =>
            {
                soda.Size = Size.Medium;
            });
        }

        [Theory]
        [InlineData("Ice")]
        [InlineData("SpecialInstructions")]
        public void ChangingIceShouldInvokePropertyChangedForIceandSpecialInstructionsForJerkedSoda(string propertyname)
        {
            var soda = new JerkedSoda();
            Assert.PropertyChanged(soda, propertyname, () =>
            {
                soda.Ice = false;
            });
        }
    }
}
