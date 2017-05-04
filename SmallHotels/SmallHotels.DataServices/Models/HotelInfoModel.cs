using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SmallHotels.Data.Models;

namespace SmallHotels.DataServices.Models
{
    public class HotelInfoModel
    {
        public HotelInfoModel()
        {
        }

        public HotelInfoModel(HotelInfo hotelInfo)
        {
            if (hotelInfo != null)
            {
                this.Id = hotelInfo.Id;
                this.Location = hotelInfo.Location;
                this.Lattitude = hotelInfo.Lattitude;
                this.Longitude = hotelInfo.Longitude;
                if (hotelInfo.Hotel != null)
                {
                    this.HotelId = hotelInfo.Hotel.Id;
                }

                this.Comments = hotelInfo.Comments.Select(c => new CommentModel(c)).ToList();
                this.Likes = hotelInfo.Likes.Select(l => new LikeModel(l)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Location { get; set; }

        public string Lattitude { get; set; }

        public string Longitude { get; set; }

        public Guid HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        public IEnumerable<LikeModel> Likes { get; set; }

        public static Expression<Func<HotelInfo, HotelInfoModel>> Create
        {
            get
            {
                return hotelInfo => new HotelInfoModel()
                {
                    Id = hotelInfo.Id,
                    Location = hotelInfo.Location,
                    Lattitude = hotelInfo.Lattitude,
                    Longitude = hotelInfo.Longitude,
                    Comments = hotelInfo.Comments.AsQueryable()
                        .Select(CommentModel.Create).ToList(),
                    Likes = hotelInfo.Likes.AsQueryable()
                        .Select(LikeModel.Create).ToList()
                };
            }
        }
    }
}
