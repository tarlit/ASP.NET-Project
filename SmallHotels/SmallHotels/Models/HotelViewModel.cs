using SmallHotels.Data.Models;
using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallHotels.Models
{
    public class HotelViewModel
    {
        public HotelViewModel()
        {
        }

        public HotelViewModel(HotelModel hotel)
        {
            if (hotel != null)
            {
                this.Id = hotel.Id;
                this.Name = hotel.Name;
                this.Email = hotel.Email;
                this.ImageUrl = hotel.ImageUrl;
                this.Description = hotel.Description;
                this.RoomsCount = hotel.RoomsCount;
                this.Rooms = hotel.Rooms.Select(r => new RoomViewModel(r)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int RoomsCount { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}