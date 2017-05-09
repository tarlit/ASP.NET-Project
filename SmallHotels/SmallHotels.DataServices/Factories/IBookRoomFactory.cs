using SmallHotels.Auth.Models;
namespace SmallHotels.DataServices.Factories
{
    using SmallHotels.Data.Models;
    using System;

    public interface IBookRoomFactory
    {
        BookRoom CreateBookRoom(Guid roomId, DateTime startDate, int nightsCount, string userId, User user);
    }
}
