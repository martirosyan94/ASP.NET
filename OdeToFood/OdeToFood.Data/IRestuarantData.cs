using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestuarantData
    {
        IEnumerable<Restuarant> GetRestuarantByName(string name = null);
        Restuarant GetRestuarantById(int id);
    }
}
