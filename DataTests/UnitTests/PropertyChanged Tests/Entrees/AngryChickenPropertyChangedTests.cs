using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using System.ComponentModel;

namespace CowboyCafe.DataTests.UnitTests.PropertyChanged_Tests.Entrees
{
    public class AngryChickenPropertyChangedTests
    {
        //Test 1: Angry Chicken should implement the INotifyPropertyChanged Interface
        [Fact]
        public void AngryChickenShouldImplementINotifyPropertyChanged()
        {
            var chicken = new AngryChicken();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(chicken);
        }

        //Test 2: Changing the "Bread" property should invoke PropertyChanged for "Bread"
        [Theory]
        [InlineData ("Bread")]
        [InlineData ("SpecialInstructions")]
        public void ChangingBreadShouldInvokePropertyChangedForBreadandSpecialInstructions(string propertyname)
        {
            var chicken = new AngryChicken();
            Assert.PropertyChanged(chicken, propertyname, () =>
            {
                chicken.Bread = false;
            });
        }

        [Theory]
        [InlineData ("Pickle")]
        [InlineData ("SpecialInstructions")]
        public void ChangingPickleShouldInvokePropertyChangedForPickleandSpecialInstructions(string propertyname)
        {
            var chicken = new AngryChicken();
            Assert.PropertyChanged(chicken, propertyname, () =>
            {
                chicken.Pickle = false;
            });
        }
    }
}
