using System;
using System.Collections.Generic;

namespace SmallHotels.Data.Models
{
    public class Room
    {
        private ICollection<DateTime> isBookedAtDate;

        public Room()
        {
            this.Id = Guid.NewGuid();
            isBookedAtDate = new HashSet<DateTime>();
        }

        public Room(string roomType, decimal pricePerNight, string imageUrl, string roomDescription, Guid hotelId)
            : this()
        {
            this.RoomType = roomType;
            this.PricePerNight = pricePerNight;
            this.ImageUrl = imageUrl;
            this.RoomDescription = roomDescription;
            this.HotelId = hotelId;
        }

        public Guid Id { get; set; }

        public string RoomType { get; set; }

        public decimal PricePerNight { get; set; }

        public string ImageUrl { get; set; }

        public string RoomDescription { get; set; }

        public virtual ICollection<DateTime> IsBookedAtDate { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
