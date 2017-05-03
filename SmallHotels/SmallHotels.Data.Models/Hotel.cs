using System;
using System.Collections.Generic;

namespace SmallHotels.Data.Models
{
    public class Hotel
    {
        private ICollection<Room> rooms;

        public Hotel()
        {
            this.rooms = new HashSet<Room>();
        }

        public Guid HotelId { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int RoomsCount { get; set; }

        public virtual HotelInfo HotelInfo { get; set; }

        public Guid RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}