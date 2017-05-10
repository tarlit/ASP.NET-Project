namespace SmallHotels.DataServices.Factories
{
    using SmallHotels.Data.Models;
    using System;

    public interface IHotelFactory
    {
        Hotel CreateHotel(string name, string email, string imageUrl, string description, string location, string lattitude, string longitude, string region);
    }
}
