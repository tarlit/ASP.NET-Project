using System;
using System.Collections.Generic;

namespace SmallHotels.Data.Models
{
    public class Region
    {
        private ICollection<Hotel> hotels;

        public Region()
        {
            this.Id = Guid.NewGuid();
            this.hotels = new HashSet<Hotel>();
        }

        public Region(string name)
            : this()
        {
            this.Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}