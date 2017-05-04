using System;
using System.Linq.Expressions;

using SmallHotels.Data.Models;

namespace SmallHotels.DataServices.Models
{
    public class RoomModel
    {
        public RoomModel()
        {
        }

        public RoomModel(Room room)
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
                if (room.Hotel != null)
                {
                    this.HotelId = room.Hotel.Id;
                }
            }
        }

        public Guid Id { get; set; }

        public string RoomType { get; set; }

        public DateTime SearchDate { get; set; }

        public bool IsBooked { get; set; }

        public decimal PricePerNight { get; set; }

        public string ImageUrl { get; set; }

        public string RoomDescription { get; set; }

        public Guid HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public static Expression<Func<Room, RoomModel>> Create
        {
            get
            {
                return room => new RoomModel()
                {
                    Id = room.Id,
                    RoomType = room.RoomType,
                    SearchDate = room.SearchDate,
                    IsBooked = room.IsBooked,
                    PricePerNight = room.PricePerNight,
                    ImageUrl = room.ImageUrl,
                    RoomDescription = room.RoomDescription
                };
            }
        }
    }
}
