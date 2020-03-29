using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.ComponentModel;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Drinks
{
    public class TexasTeaPropertyChangedTests
    {
        [Fact]
        public void TexasTeaShouldImplementINotifyPropertyChanged()
        {
            var tea = new TexasTea();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tea);
        }

        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForTexasTea(string propertyname)
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, propertyname, () =>
            {
                tea.Size = Size.Medium;
            });
        }

        [Theory]
        [InlineData("Ice")]
        [InlineData("SpecialInstructions")]
        public void ChangingIceShouldInvokePropertyChangedForIceandSpecialInstructionsForTexasTea(string propertyname)
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, propertyname, () =>
            {
                tea.Ice = false;
            });
        }

        [Theory]
        [InlineData("Lemon")]
        [InlineData("SpecialInstructions")]
        public void ChangingLemonShouldInvokePropertyChangedForIceandSpecialInstructionsForTexasTea(string propertyname)
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, propertyname, () =>
            {
                tea.Lemon = true;
            });
        }

        [Fact]
        public void ChangingSweetShouldInvokePropertyChangedForSweetForTexasTea()
        {
            var tea = new TexasTea();
            Assert.PropertyChanged(tea, "Sweet", () =>
            {
                tea.Sweet = false;
            });
        }
    }
}
