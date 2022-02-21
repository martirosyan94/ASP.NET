using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restuarants
{
    public class ListModel : PageModel
    {
        private readonly IRestuarantData RestuarantsData;
        public IEnumerable<Restuarant> Restuarants { get; set; }

        public ListModel(IRestuarantData restuarantData)
        {
            RestuarantsData = restuarantData;
        }
        public void OnGet()
        {
            Restuarants = RestuarantsData.GetAllRestuarants();
        }
    }
}
