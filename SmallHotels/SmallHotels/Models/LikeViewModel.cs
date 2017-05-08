using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallHotels.Models
{
    public class LikeViewModel
    {
        public LikeViewModel()
        {
        }

        public LikeViewModel(LikeModel like)
        {
            if (like != null)
            {
                this.Id = like.Id;
            }
        }

        public Guid Id { get; set; }
    }
}