using SmallHotels.DataServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmallHotels.Models
{
    public class RegionViewModel
    {
        public RegionViewModel()
        {
        }

        public RegionViewModel(RegionModel region)
        {
            if (region != null)
            {
                this.Name = region.Name;
                this.Hotels = region.Hotels.Select(h => new HotelViewModel(h)).ToList();
            }            
        }

        public string Name { get; set; }

        public IEnumerable<HotelViewModel> Hotels { get; set; }
    }
}