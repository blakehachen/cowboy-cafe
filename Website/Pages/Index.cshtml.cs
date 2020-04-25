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

        public IEnumerable<IOrderItem> Entrees { get; protected set; }
        public IEnumerable<IOrderItem> Sides { get; protected set; }
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
        public uint? CalorieMin { get; set; }

        /// <summary>
        /// maximum calories
        /// </summary>
        [BindProperty]
        public uint? CalorieMax { get; set; }
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

        public void OnGet()
        {

            Entrees = Menu.Entrees;
            Sides = Menu.Sides;
            Drinks = Menu.Drinks;
            
        }

        public void OnPost()
        {

            Entrees = Menu.Search(Menu.Entrees, SearchTerms);
            Entrees = Menu.FilterByCategory(Entrees, ItemTypes);
            Entrees = Menu.FilterByCalories(Entrees, CalorieMin, CalorieMax);

            Sides = Menu.Search(Menu.Sides, SearchTerms);
            Sides = Menu.FilterByCategory(Sides, ItemTypes);
            Sides = Menu.FilterByCalories(Sides, CalorieMin, CalorieMax);

            Drinks = Menu.Search(Menu.Drinks, SearchTerms);
            Drinks = Menu.FilterByCategory(Drinks, ItemTypes);
            Drinks = Menu.FilterByCalories(Drinks, CalorieMin, CalorieMax);


        }
    }
}
