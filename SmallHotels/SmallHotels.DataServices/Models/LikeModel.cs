using System;
using System.Linq.Expressions;

using SmallHotels.Data.Models;

namespace SmallHotels.DataServices.Models
{
    public class LikeModel
    {
        public LikeModel()
        {
        }

        public LikeModel(Like like)
        {
            this.Id = like.Id;
            if (like.UserId != null)
            {
                this.UserId = like.UserId;
            }

            if (like.HotelInfo != null)
            {
                this.HotelInfoId = like.HotelInfo.Id;
            }
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid HotelInfoId { get; set; }

        public HotelInfoModel HotelInfo { get; set; }

        public static Expression<Func<Like, LikeModel>> Create
        {
            get
            {
                return like => new LikeModel()
                {
                    Id = like.Id
                };
            }
        }
    }
}
