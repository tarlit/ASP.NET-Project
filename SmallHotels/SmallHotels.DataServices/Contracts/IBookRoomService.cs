using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.DataServices.Contracts
{
    public interface IBookRoomService
    {
        void BookOneRoom(Guid roomId, DateTime startDate, int nightsCount, string userId, User user);

        IEnumerable<BookRoom> GetBookedRoomsForUser(string userId, int page, int pageSize);

        IEnumerable<BookRoom> GetAllBookRooms();

        BookRoom GetById(Guid bookRoom);

        void UpdateBookRoomIndo(Guid bookRoomId, string firstName, string lastName, string phone, string address, bool status);

        int GetPagesCountForUser(string userId, int pageSize);

        int GetTotalPagesCount(string query, int pageSize);

        IEnumerable<BookRoom> GetBookedRoomsByPAge(string query, int page, int pageSize);
    }
}
