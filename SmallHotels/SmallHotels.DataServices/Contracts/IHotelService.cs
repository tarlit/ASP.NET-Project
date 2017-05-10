using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;

namespace SmallHotels.DataServices.Contracts
{
    public interface IHotelService
    {
        Hotel GetById(Guid? id);

        IEnumerable<Hotel> GetHotelsByName(string searchTerm);

        IEnumerable<Hotel> GetHotelsByRegion(Guid regionId);

        void CreateHotel(string name, string email, string imageUrl, string description, string location, string lattitude, string longitude, Guid regionId);

        void EditHotel(Guid hotelId, string name, string email, string imageUrl, string description);

        void DeleteHotel(Guid? hotelId);

        int GetPagesCount(string query);

        IEnumerable<Hotel> GetHotelsByPage(string query, int page, int pageSize);

        void AddComment(Guid hotelId, string userId, string content);

        void DeleteComment(Guid commentId);
        
        void ToggleLike(Guid hotelId, string userId);

        bool IsHotelLiked(Guid hotelId, string userId);
    }
}