using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SmallHotels.Data.Models;

namespace SmallHotels.DataServices.Models
{
    public class HotelModel
    {
        public HotelModel()
        {
        }

        public HotelModel(Hotel hotel)
        {
            if (hotel != null)
            {
                this.Id = hotel.Id;
                this.Name = hotel.Name;
                this.Email = hotel.Email;
                this.ImageUrl = hotel.ImageUrl;
                this.Description = hotel.Description;
                this.RoomsCount = hotel.RoomsCount;
                if (hotel.HotelInfo != null)
                {
                    this.HotelInfoId = hotel.HotelInfo.Id;
                }

                if (hotel.Region != null)
                {
                    this.RegionId = hotel.Region.Id;
                }

                this.Rooms = hotel.Rooms.Select(r => new RoomModel(r)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int RoomsCount { get; set; }

        public Guid HotelInfoId { get; set; }

        public HotelInfoModel HotelInfo { get; set; }

        public Guid RegionId { get; set; }

        public RegionModel Region { get; set; }

        public IEnumerable<RoomModel> Rooms { get; set; }

        public static Expression<Func<Hotel, HotelModel>> Create
        {
            get
            {
                return hotel => new HotelModel()
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Email = hotel.Email,
                    ImageUrl = hotel.ImageUrl,
                    Description = hotel.Description,
                    RoomsCount = hotel.RoomsCount,
                    Rooms = hotel.Rooms.AsQueryable()
                        .Select(RoomModel.Create).ToList()
                };
            }
        }
    }
}
