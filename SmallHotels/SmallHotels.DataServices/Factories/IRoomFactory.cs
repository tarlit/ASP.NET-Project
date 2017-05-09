namespace SmallHotels.DataServices.Factories
{
    using SmallHotels.Data.Models;
    using System;

    public interface IRoomFactory
    {
        Room CreateRoom(string roomType, decimal pricePerNight, string imageUrl, string roomDescription, Guid hotelId);
    }
}
