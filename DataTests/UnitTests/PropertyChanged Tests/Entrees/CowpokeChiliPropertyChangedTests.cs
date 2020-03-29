using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Entrees
{
    public class CowpokeChiliPropertyChangedTests
    {
        [Fact]
        public void CowpokeChiliShouldImplementINotifyPropertyChanged()
        {
            var chili = new CowpokeChili();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(chili);
        }

        [Theory]
        [InlineData("Cheese")]
        [InlineData("SpecialInstructions")]
        public void ChangingCheeseShouldInvokePropertyChangedForCheeseandSpecialInstructions(string propertyname)
        {
            var chili = new CowpokeChili();
            Assert.PropertyChanged(chili, propertyname, () =>
            {
                chili.Cheese = false;
            });
        }

        [Theory]
        [InlineData("SourCream")]
        [InlineData("SpecialInstructions")]
        public void ChangingSourCreamShouldInvokePropertyChangedForSourCreamandSpecialInstructions(string propertyname)
        {
            var chili = new CowpokeChili();
            Assert.PropertyChanged(chili, propertyname, () =>
            {
                chili.SourCream = false;
            });
        }

        [Theory]
        [InlineData("GreenOnions")]
        [InlineData("SpecialInstructions")]
        public void ChangingGreenOnionsShouldInvokePropertyChangedForGreenOnionsandSpecialInstructions(string propertyname)
        {
            var chili = new CowpokeChili();
            Assert.PropertyChanged(chili, propertyname, () =>
            {
                chili.GreenOnions = false;
            });
        }

        [Theory]
        [InlineData("TortillaStrips")]
        [InlineData("SpecialInstructions")]
        public void ChangingTortillaStripsShouldInvokePropertyChangedForTortillaStripsandSpecialInstructions(string propertyname)
        {
            var chili = new CowpokeChili();
            Assert.PropertyChanged(chili, propertyname, () =>
            {
                chili.TortillaStrips = false;
            });
        }
    }
}
