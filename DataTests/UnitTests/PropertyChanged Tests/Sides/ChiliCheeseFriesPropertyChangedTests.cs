using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;


namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Sides
{
    public class ChiliCheeseFriesPropertyChangedTests
    {
        [Fact]
        public void ChiliCheeseFriesShouldImplementINotifyPropertyChanged()
        {
            var chilicheesefries = new ChiliCheeseFries();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(chilicheesefries);
        }



        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForChiliCheeseFries(string propertyname)
        {
            var chilicheesefries = new ChiliCheeseFries();
            Assert.PropertyChanged(chilicheesefries, propertyname, () =>
            {
                chilicheesefries.Size = Size.Medium;
            });
        }
    }
}
