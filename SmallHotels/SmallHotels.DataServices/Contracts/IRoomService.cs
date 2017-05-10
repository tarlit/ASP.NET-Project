using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.DataServices.Contracts
{
    public interface IRoomService
    {
        void CreateRoom(string roomType, decimal pricePerNight, string imageUrl, string roomDescription, Guid hotelId);

        void EditRoom(string roomType, decimal pricePerNight, string imageUrl, string roomDescription);

        void DeleteRoom(Guid roomId);
    }
}
