using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallHotels.Models
{
    public class RoomViewModel
    {
        public RoomViewModel()
        {
        }

        public RoomViewModel(RoomModel room)
        {
            if (room != null)
            {
                this.Id = room.Id;
                this.RoomType = room.RoomType;
                this.SearchDate = room.SearchDate;
                this.IsBooked = room.IsBooked;
                this.PricePerNight = room.PricePerNight;
                this.ImageUrl = room.ImageUrl;
                this.RoomDescription = room.RoomDescription;
            }
        }

        public Guid Id { get; set; }

        public string RoomType { get; set; }

        public DateTime SearchDate { get; set; }

        public bool IsBooked { get; set; }

        public decimal PricePerNight { get; set; }

        public string ImageUrl { get; set; }

        public string RoomDescription { get; set; }
    }
}