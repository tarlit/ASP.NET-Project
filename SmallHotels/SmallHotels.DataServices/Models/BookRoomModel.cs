using System;
using System.Linq.Expressions;

using SmallHotels.Data.Models;

namespace SmallHotels.DataServices.Models
{
    public class BookRoomModel
    {
        public BookRoomModel()
        {
        }

        public BookRoomModel(BookRoom bookRoom)
        {
            if (bookRoom != null)
            {
                this.Id = bookRoom.Id;
                this.StartDate = bookRoom.StartDate;
                this.NightsCount = bookRoom.NightsCount;
                this.TotalPrice = bookRoom.TotalPrice;
                if (bookRoom.Room != null)
                {
                    this.RoomId = bookRoom.Room.Id;
                }

                if (bookRoom.User != null)
                {
                    this.UserId = bookRoom.UserId;
                }
            }
        }

        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public int NightsCount { get; set; }

        public decimal TotalPrice { get; set; }

        public Guid RoomId { get; set; }

        public RoomModel Room { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUserModel User { get; set; }

        public static Expression<Func<BookRoom, BookRoomModel>> Create
        {
            get
            {
                return bookRoom => new BookRoomModel()
                {
                    Id = bookRoom.Id,
                    StartDate = bookRoom.StartDate,
                    NightsCount = bookRoom.NightsCount,
                    TotalPrice = bookRoom.TotalPrice
                };
            }
        }
    }
}
