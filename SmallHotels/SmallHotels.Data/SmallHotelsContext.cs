using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System;
using SmallHotels.Auth.Models;

namespace SmallHotels.Data
{
    public class SmallHotelsContext : DbContext, IDbContextSaveChanges
    {
        public SmallHotelsContext()
            : base("SmallHotels")
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Hotel> Hotels { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<BookRoom> BookRooms { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}