using SmallHotels.Auth.Models;
using SmallHotels.Data.Models;
using System.Data.Entity;

namespace SmallHotels.Data
{
    public interface ISmallHotelsContext
    {
        IDbSet<Hotel> Hotels { get; set; }
        IDbSet<Region> Regions { get; set; }
        IDbSet<Room> Rooms { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Like> Likes { get; set; }
        IDbSet<BookRoom> BookRooms { get; set; }

        int SaveChanges();
    }
}
