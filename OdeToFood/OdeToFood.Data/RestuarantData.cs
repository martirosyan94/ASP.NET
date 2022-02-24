using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class RestuarantData : IRestuarantData
    {
        public IEnumerable<Restuarant> Restuarants { get; set; }
        public RestuarantData()
        {
            Restuarants = new List<Restuarant>
                {
                    new Restuarant { Id=0, Name = "La pizza", Cousine = CousineType.Italian, Location = "Italy" },
                    new Restuarant { Id=1, Name = "Taco de la", Cousine = CousineType.Mexician, Location = "Mexico" },
                    new Restuarant { Id=2, Name = "Ind", Cousine = CousineType.Indian, Location = "India" },
                    new Restuarant { Id=3, Name = "Malloco", Cousine = CousineType.None, Location = "Armenia" }
                };
        }
        public IEnumerable<Restuarant> GetRestuarantByName(string name = null)
        {
            return Restuarants.Where(r => name is null ? true : r.Name.StartsWith(name));
        }

        public Restuarant GetRestuarantById(int id)
        {
            return Restuarants.FirstOrDefault(r => r.Id == id);
        }
    }
}
