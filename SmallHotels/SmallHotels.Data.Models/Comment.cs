using SmallHotels.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.Data.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Guid HotelInfoId { get; set; }

        public virtual HotelInfo HotelInfo { get; set; }
    }
}
