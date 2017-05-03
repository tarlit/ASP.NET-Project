using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.Data.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }

        public string RoomType { get; set; }

        public DateTime? SearchDate { get; set; }

        public bool IsBooked { get; set; }

        public decimal PricePerNight { get; set; }

        public string ImageUrl { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
