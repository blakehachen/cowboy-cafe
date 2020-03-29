using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Sides
{
    public class PanDeCampoPropertyChangedTests
    {


        [Fact]
        public void PanDeCampoShouldImplementINotifyPropertyChanged()
        {
            var pandecampo = new PanDeCampo();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pandecampo);
        }



        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeShouldInvokePropertyChangedForSizeandPriceandCaloriesForPanDeCampo(string propertyname)
        {
            var pandecampo = new BakedBeans();
            Assert.PropertyChanged(pandecampo, propertyname, () =>
            {
                pandecampo.Size = Size.Medium;
            });
        }
    }
}
