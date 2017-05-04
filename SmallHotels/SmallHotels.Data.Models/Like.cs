using System;

namespace SmallHotels.Data.Models
{
    public class Like
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid HotelInfoId { get; set; }

        public virtual HotelInfo HotelInfo { get; set; }
    }
}
