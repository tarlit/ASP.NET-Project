namespace SmallHotels.DataServices.Factories
{
    using SmallHotels.Data.Models;
    using System;

    public interface ICommentFactory
    {
        Comment CreateComment(string userId, string content, Guid hotelId);
    }
}
