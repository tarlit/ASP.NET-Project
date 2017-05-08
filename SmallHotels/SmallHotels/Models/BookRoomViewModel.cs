using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallHotels.Models
{
    public class BookRoomViewModel
    {
        public BookRoomViewModel()
        {
        }

        public BookRoomViewModel(BookRoomModel bookRoom)
        {
            if (bookRoom != null)
            {
                this.Id = bookRoom.Id;
                this.StartDate = bookRoom.StartDate;
                this.NightsCount = bookRoom.NightsCount;
                this.TotalPrice = bookRoom.TotalPrice;
            }
        }

        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public int NightsCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}