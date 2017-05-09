using System;
using System.Collections.Generic;

namespace SmallHotels.Data.Models
{
    public class Hotel
    {
        private ICollection<Room> rooms;
        private ICollection<Comment> comments;
        private ICollection<Like> likes;

        public Hotel()
        {
            this.Id = Guid.NewGuid();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
            this.rooms = new HashSet<Room>();
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
        }

        public Hotel(string name, string email, string imageUrl, string description, string location, string lattitude, string longitude, Guid regionId)
            : this()
        {
            this.Name = name;
            this.Email = email;
            this.ImageUrl = imageUrl;
            this.Description = description;
            this.Location = location;
            this.Lattitude = lattitude;
            this.Longitude = longitude;
            this.RegionId = regionId;
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Lattitude { get; set; }

        public string Longitude { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public Guid RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}