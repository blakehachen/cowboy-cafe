using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using System.Linq;

namespace CowboyCafe.DataTests.UnitTests
{
    public class MenuTests
    {
        [Theory]
        [InlineData(typeof(ChiliCheeseFries))]
        [InlineData(typeof(BakedBeans))]
        [InlineData(typeof(PanDeCampo))]
        [InlineData(typeof(CornDodgers))]
        public void SidesShouldContainAllSideItems(Type side)
        {
            var sides = new List<Type>();
            foreach(IOrderItem item in Menu.Sides)
            {
                sides.Add(item.GetType());
            }
            Assert.Contains(side, sides);
        }

        [Fact]
        public void SidesShouldHaveOnlyFourItems()
        {
            Assert.Equal(4, Menu.Sides.Count());
        }

        [Theory]
        [InlineData(typeof(CowboyCoffee))]
        [InlineData(typeof(JerkedSoda))]
        [InlineData(typeof(TexasTea))]
        [InlineData(typeof(Water))]
        public void DrinksShouldContainAllDrinkItems(Type drink)
        {
            var drinks = new List<Type>();
            foreach(IOrderItem item in Menu.Drinks)
            {
                drinks.Add(item.GetType());
            }
            Assert.Contains(drink, drinks);
        }

        [Fact]
        public void DrinksShouldHaveOnlyFourItems()
        {
            Assert.Equal(4, Menu.Drinks.Count());
        }

        [Theory]
        [InlineData(typeof(AngryChicken))]
        [InlineData(typeof(CowpokeChili))]
        [InlineData(typeof(PecosPulledPork))]
        [InlineData(typeof(RustlersRibs))]
        [InlineData(typeof(TrailBurger))]
        [InlineData(typeof(DakotaDoubleBurger))]
        [InlineData(typeof(TexasTripleBurger))]
        public void EntreesShouldContainAllEntreeItems(Type entree)
        {
            var entrees = new List<Type>();
            foreach(IOrderItem item in Menu.Entrees)
            {
                entrees.Add(item.GetType());
            }
            Assert.Contains(entree, entrees);
        }

        [Fact]
        public void EntreesShouldHaveOnlySevenItems()
        {
            Assert.Equal(7, Menu.Entrees.Count());
        }
        
        [Theory]
        [InlineData(typeof(BakedBeans))]
        [InlineData(typeof(PanDeCampo))]
        [InlineData(typeof(CornDodgers))]
        [InlineData(typeof(CowboyCoffee))]
        [InlineData(typeof(JerkedSoda))]
        [InlineData(typeof(TexasTea))]
        [InlineData(typeof(Water))]
        [InlineData(typeof(AngryChicken))]
        [InlineData(typeof(CowpokeChili))]
        [InlineData(typeof(PecosPulledPork))]
        [InlineData(typeof(RustlersRibs))]
        [InlineData(typeof(TrailBurger))]
        [InlineData(typeof(DakotaDoubleBurger))]
        [InlineData(typeof(TexasTripleBurger))]
        public void CompleteMenuShouldContainAllTypes(Type type)
        {
            var all = new List<Type>();
            foreach(IOrderItem item in Menu.CompleteMenu)
            {
                all.Add(item.GetType());
            }
            Assert.Contains(type, all);

        }

        [Fact]
        public void CompleteMenuShouldHaveFifteenItems()
        {
            Assert.Equal(15, Menu.CompleteMenu.Count());
        }

        [Theory]
        [InlineData("A")]
        [InlineData("Angry")]
        [InlineData("ch")]
        [InlineData("cow")]
        [InlineData("p")]
        [InlineData("")]
        public void CollectionOfSearchedItemsShouldContainSearchTerms(string terms)
        {
            var searched = Menu.Search(Menu.CompleteMenu, terms);
            if (terms == "") Assert.Equal(searched, Menu.CompleteMenu);
            foreach(IOrderItem item in searched)
            {
                Assert.Contains(terms.ToLower(), item.ToString().ToLower());
            }

        }

        [Theory]
        [InlineData(1.23, null)]
        [InlineData(1.00, 6.00)]
        [InlineData(0.06, 1.20)]
        [InlineData(null, null)]
        [InlineData(null, 3.20)]
        public void CollectionOfItemsFilteredByPriceShouldFitTheCriteria(double? min, double? max)
        {
            var searched = Menu.FilterByPrice(Menu.CompleteMenu, min, max);
            if (min == null && max == null) Assert.Equal(searched, Menu.CompleteMenu);
            foreach(IOrderItem item in Menu.CompleteMenu)
            {
                if(min == null && max != null && item.Price <= max)
                {
                    Assert.Contains(item, searched);
                }

                if (max == null && min != null && item.Price >= min)
                {
                    Assert.Contains(item, searched);
                }

                if(max != null && min != null && item.Price >= min && item.Price <= max)
                {
                    Assert.Contains(item, searched);
                }
            }
            
        }

        [Theory]
        [InlineData(100, 500)]
        [InlineData(200, 300)]
        [InlineData(0, 120)]
        [InlineData(500, 700)]
        [InlineData(null, 500)]
        [InlineData(100, null)]
        [InlineData(null, null)]
        public void CollectionOfItemsFilteredByCaloriesShouldFitTheCriteria(int? min, int? max)
        {
            var searched = Menu.FilterByCalories(Menu.CompleteMenu, min, max);
            if (min == null && max == null) Assert.Equal(searched, Menu.CompleteMenu);
            foreach (IOrderItem item in Menu.CompleteMenu)
            {
                if (min == null && max != null && item.Calories <= max)
                {
                    Assert.Contains(item, searched);
                }

                if (max == null && min != null && item.Calories >= min)
                {
                    Assert.Contains(item, searched);
                }

                if (max != null && min != null && item.Calories >= min && item.Calories <= max)
                {
                    Assert.Contains(item, searched);
                }
            }

        }
        //Tests All ItemTypes Checked, could not figure out a way to test individual checked item types
        [Fact]
        public void CollectionOfItemsFilteredByCategoryShouldFitTheCriteria()
        {
            var searched = Menu.FilterByCategory(Menu.CompleteMenu, Menu.ItemTypes);
            Assert.Equal(searched, Menu.CompleteMenu);
            
        }

        [Fact]
        public void ItemTypesShouldHaveEntreeSideAndDrink()
        {
            var ItemTypes = Menu.ItemTypes;
            Assert.Contains("Entree", ItemTypes);
            Assert.Contains("Side", ItemTypes);
            Assert.Contains("Drink", ItemTypes);
        }

        [Fact]
        public void ItemTypesShouldHaveThreeItems()
        {
            Assert.Equal(3, Menu.ItemTypes.Count());
        }
    }
}

