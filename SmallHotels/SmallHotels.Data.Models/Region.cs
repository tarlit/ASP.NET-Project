using System;
using System.Collections.Generic;

namespace SmallHotels.Data.Models
{
    public class Region
    {
        private ICollection<Hotel> hotels;

        public Region()
        {
            this.hotels = new HashSet<Hotel>();
        }

        public Guid RegionId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}