using System;

namespace SmallHotels.Data.Models
{
    public class BookRoom
    {
        public BookRoom()
        {
            this.Id = Guid.NewGuid();
            this.Status = "Awaiting confirmation";
            this.CreatedOn = DateTime.Now;
        }

        public BookRoom(Guid roomId, DateTime startDate, int nightsCount, string userId, User user)
            : this()
        {
            this.RoomId = roomId;
            this.StartDate = startDate;
            this.NightsCount = nightsCount;
            this.UserId = userId;
            this.User = user;
        }

        public Guid Id { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime StartDate { get; set; }

        public int NightsCount { get; set; }

        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
