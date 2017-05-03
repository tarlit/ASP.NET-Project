using SmallHotels.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.Data.Models
{
    public class BookRoom
    {
        public Guid BookRoomId { get; set; }

        public DateTime? StartDate { get; set; }

        public int NightsCount { get; set; }

        public decimal TotalPrice { get; set; }

        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
