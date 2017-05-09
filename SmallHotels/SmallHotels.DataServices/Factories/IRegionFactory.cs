using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.DataServices.Factories
{
    public interface IRegionFactory
    {
        Region CreateRegion(string name);
    }
}
