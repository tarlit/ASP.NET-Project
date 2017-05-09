using System;

namespace SmallHotels.Data.Models
{
    public class Like
    {
        public Like()
        {
            this.Id = Guid.NewGuid();
        }

        public Like(string userId, Guid hotelId)
            : this()
        {
            this.UserId = userId;
            this.HotelId = hotelId;
        }

        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
