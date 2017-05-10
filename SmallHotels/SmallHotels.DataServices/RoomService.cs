using SmallHotels.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.DataServices
{
    public class RoomService : IRoomService
    {
        public void CreateRoom(string roomType, decimal pricePerNight, string imageUrl, string roomDescription, Guid hotelId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoom(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public void EditRoom(string roomType, decimal pricePerNight, string imageUrl, string roomDescription)
        {
            throw new NotImplementedException();
        }
    }
}
