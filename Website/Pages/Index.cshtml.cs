using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CowboyCafe.Data;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        /// <summary>
        /// Holds Entrees Collection
        /// </summary>
        public IEnumerable<IOrderItem> Entrees { get; protected set; }
        /// <summary>
        /// Holds Sides Collection
        /// </summary>
        public IEnumerable<IOrderItem> Sides { get; protected set; }
        /// <summary>
        /// Holds Drinks Collection
        /// </summary>
        public IEnumerable<IOrderItem> Drinks { get; protected set; }
        /// <summary>
        /// The current search terms
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// Gets types of different order items 
        /// </summary>
        [BindProperty]
        public string[] ItemTypes { get; set; }

        /// <summary>
        /// minimum calories
        /// </summary>
        [BindProperty]
        public int? CalorieMin { get; set; }

        /// <summary>
        /// maximum calories
        /// </summary>
        [BindProperty]
        public int? CalorieMax { get; set; }
        /// <summary>
        /// maximum price
        /// </summary>
        [BindProperty]
        public double? PriceMax { get; set; }
        /// <summary>
        /// minimum calories
        /// </summary>
        [BindProperty]
        public double? PriceMin { get; set; }
        
        
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Initializes the Webpage with original Menu
        /// </summary>
        public void OnGet()
        {

            Entrees = Menu.Entrees;
            Sides = Menu.Sides;
            Drinks = Menu.Drinks;
            
        }

        /// <summary>
        /// Modifies Webpage to Include Filtering by search, Calories, and price.
        /// </summary>
        public void OnPost()
        {

            Entrees = Menu.Search(Menu.Entrees, SearchTerms);
            Entrees = Menu.FilterByCategory(Entrees, ItemTypes);
            Entrees = Menu.FilterByCalories(Entrees, CalorieMin, CalorieMax);
            Entrees = Menu.FilterByPrice(Entrees, PriceMin, PriceMax);

            Sides = Menu.Search(Menu.Sides, SearchTerms);
            Sides = Menu.FilterByCategory(Sides, ItemTypes);
            Sides = Menu.FilterByCalories(Sides, CalorieMin, CalorieMax);
            Sides = Menu.FilterByPrice(Sides, PriceMin, PriceMax);

            Drinks = Menu.Search(Menu.Drinks, SearchTerms);
            Drinks = Menu.FilterByCategory(Drinks, ItemTypes);
            Drinks = Menu.FilterByCalories(Drinks, CalorieMin, CalorieMax);
            Drinks = Menu.FilterByPrice(Drinks, PriceMin, PriceMax);

        }
    }
}
