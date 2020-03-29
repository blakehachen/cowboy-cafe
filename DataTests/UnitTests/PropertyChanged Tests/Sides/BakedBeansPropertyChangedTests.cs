using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Sides
{
    public class BakedBeansPropertyChangedTests
    {


        [Fact]
        public void BakedBeansShouldImplementINotifyPropertyChanged()
        {
            var beans = new BakedBeans();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(beans);
        }



        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForBakedBeans(string propertyname)
        {
            var beans = new BakedBeans();
            Assert.PropertyChanged(beans, propertyname, () =>
            {
                beans.Size = Size.Medium;
            });
        }
    }
}
