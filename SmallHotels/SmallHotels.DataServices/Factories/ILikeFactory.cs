namespace SmallHotels.DataServices.Factories
{
    using SmallHotels.Data.Models;
    using System;

    public interface ILikeFactory
    {
        Like CreateLike(string userId, Guid hotelId);
    }
}
