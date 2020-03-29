using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Drinks
{
    public class WaterPropertyChangedTests
    {
        [Fact]
        public void WaterShouldImplementINotifyPropertyChanged()
        {
            var water = new Water();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(water);
        }

        [Theory]
        [InlineData ("Lemon")]
        [InlineData ("SpecialInstructions")]
        public void ChangingLemonShouldInvokePropertyChangedForLemonandSpecialInstructionsForWater(string propertyname)
        {
            var water = new Water();
            Assert.PropertyChanged(water, propertyname, () =>
            {
                water.Lemon = true;
            });
        }


        [Theory]
        [InlineData("Ice")]
        [InlineData("SpecialInstructions")]
        public void ChangingIceShouldInvokePropertyChangedForIceandSpecialInstructionsForWater(string propertyname)
        {
            var water = new Water();
            Assert.PropertyChanged(water, propertyname, () =>
            {
                water.Ice = false;
            });
        }

        [Fact]
        public void ChangingSizeShouldInvokePropertyChangedForSizeForWater()
        {
            var water = new Water();
            Assert.PropertyChanged(water, "Size", () =>
            {
                water.Size = Size.Medium;
            });
        }
    }
}
