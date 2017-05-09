namespace SmallHotels.Data.Models
{
    using System;

    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
        }

        public Comment(string userId, string content, Guid hotelId)
            : this()
        {
            this.Content = content;
            this.CreatedOn = DateTime.Now;
            this.UserId = userId;
            this.HotelId = hotelId;
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
