using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SmallHotels.Data.Models;

namespace SmallHotels.DataServices.Models
{
    public class RegionModel
    {
        public RegionModel()
        {
        }

        public RegionModel(Region region)
        {
            if (region != null)
            {
                this.Id = region.Id;
                this.Name = region.Name;
                this.Hotels = region.Hotels.Select(h => new HotelModel(h)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<HotelModel> Hotels { get; set; }

        public static Expression<Func<Region, RegionModel>> Create
        {
            get
            {
                return r => new RegionModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Hotels = r.Hotels.AsQueryable()
                        .Select(HotelModel.Create).ToList()
                };
            }
        }
    }
}