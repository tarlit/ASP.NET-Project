using System;
using System.Collections.Generic;

namespace SmallHotels.Data.Models
{
    public class HotelInfo
    {
        private ICollection<Comment> comments;
        private ICollection<Like> likes;

        public HotelInfo()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
        }

        public Guid Id { get; set; }

        public string Location { get; set; }

        public string Lattitude { get; set; }

        public string Longitude { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
