using System;

namespace SmallHotels.Data.Models
{
    public class Room
    {
        public Guid Id { get; set; }

        public string RoomType { get; set; }

        public DateTime SearchDate { get; set; }

        public bool IsBooked { get; set; }

        public decimal PricePerNight { get; set; }

        public string ImageUrl { get; set; }

        public string RoomDescription { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
