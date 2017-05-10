using SmallHotels.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallHotels.Data.Models;

namespace SmallHotels.DataServices
{
    public class BookRoomService : IBookRoomService
    {
        public void BookOneRoom(Guid roomId, DateTime startDate, int nightsCount, string userId, User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookRoom> GetAllBookRooms()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookRoom> GetBookedRoomsByPAge(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookRoom> GetBookedRoomsForUser(string userId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public BookRoom GetById(Guid bookRoom)
        {
            throw new NotImplementedException();
        }

        public int GetPagesCountForUser(string userId, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetTotalPagesCount(string query, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookRoomIndo(Guid bookRoomId, string firstName, string lastName, string phone, string address, bool status)
        {
            throw new NotImplementedException();
        }
    }
}
