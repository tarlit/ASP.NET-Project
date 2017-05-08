using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallHotels.Models
{
    public class HotelInfoViewModel
    {
        public HotelInfoViewModel()
        {
        }

        public HotelInfoViewModel(HotelInfoModel hotelInfo)
        {
            if (hotelInfo != null)
            {
                this.Id = hotelInfo.Id;
                this.Location = hotelInfo.Location;
                this.Lattitude = hotelInfo.Lattitude;
                this.Longitude = hotelInfo.Longitude;
                this.Comments = hotelInfo.Comments.Select(c => new CommentViewModel(c)).ToList();
                this.Likes = hotelInfo.Likes.Select(l => new LikeViewModel(l)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Location { get; set; }

        public string Lattitude { get; set; }

        public string Longitude { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<LikeViewModel> Likes { get; set; }
    }
}