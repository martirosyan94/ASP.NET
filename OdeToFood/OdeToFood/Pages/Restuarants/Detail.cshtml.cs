using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restuarants
{
    public class DetailModel : PageModel
    {
        private readonly IRestuarantData RestuarantData;
        public Restuarant Restuarant { get; set; }
        public DetailModel(IRestuarantData restuarantData)
        {
            RestuarantData = restuarantData;    
        }
        public void OnGet(int restuarantId)
        {
            Restuarant = RestuarantData.GetRestuarantById(restuarantId);
        }
    }
}
