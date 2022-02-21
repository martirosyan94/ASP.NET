using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public class RestuarantData : IRestuarantData
    {
        public IEnumerable<Restuarant> Restuarants { get; set; }
        public RestuarantData() 
        {
            Restuarants = new List<Restuarant>
                {
                    new Restuarant { Name = "La pizza", Cousine = CousineType.Italian, Location = "Italy" },
                    new Restuarant { Name = "Taco de la", Cousine = CousineType.Mexician, Location = "Mexico" },
                    new Restuarant { Name = "Ind", Cousine = CousineType.Indian, Location = "India" },
                    new Restuarant { Name = "Malloco", Cousine = CousineType.None, Location = "Armenia" }
                };
        }
        public IEnumerable<Restuarant> GetAllRestuarants()
        {
            return Restuarants;
        }
    }
}
