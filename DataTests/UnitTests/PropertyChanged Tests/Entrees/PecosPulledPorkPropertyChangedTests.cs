using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xunit;
using CowboyCafe.Data;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Entrees
{
    public class PecosPulledPorkPropertyChangedTests
    {
        [Fact]
        public void PecosPulledPorkShouldImplementINotifyPropertyChanged()
        {
            var pork = new PecosPulledPork();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pork);
        }

        [Theory]
        [InlineData("Bread")]
        [InlineData("SpecialInstructions")]
        public void ChangingBreadShouldInvokePropertyChangedForBreadandSpecialInstructions(string propertyname)
        {
            var pork = new PecosPulledPork();
            Assert.PropertyChanged(pork, propertyname, () =>
            {
                pork.Bread = false;
            });
        }

        [Theory]
        [InlineData("Pickle")]
        [InlineData("SpecialInstructions")]
        public void ChangingPickleShouldInvokePropertyChangedForPickleandSpecialInstructions(string propertyname)
        {
            var pork = new PecosPulledPork();
            Assert.PropertyChanged(pork, propertyname, () =>
            {
                pork.Pickle = false;
            });
        }
    }
}
