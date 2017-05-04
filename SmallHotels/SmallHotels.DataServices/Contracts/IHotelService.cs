using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;

namespace SmallHotels.DataServices.Contracts
{
    public interface IHotelService
    {
        HotelModel GetById(Guid? id);

        IEnumerable<HotelModel> GetHotelsByName(string searchTerm);
    }
}