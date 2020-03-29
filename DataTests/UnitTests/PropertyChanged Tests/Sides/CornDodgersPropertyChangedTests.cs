using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Sides
{
    public class CornDodgersPropertyChangedTests
    {


        [Fact]
        public void CornDodgersShouldImplementINotifyPropertyChanged()
        {
            var corndodgers = new BakedBeans();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(corndodgers);
        }



        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForCornDodgers(string propertyname)
        {
            var corndodgers = new BakedBeans();
            Assert.PropertyChanged(corndodgers, propertyname, () =>
            {
                corndodgers.Size = Size.Medium;
            });
        }
    }
}
