using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmallHotels.DataServices.Contracts
{
    public interface ICartService
    {
        HttpCookie WriteCookie(HttpCookie cookie, string email, string roomId, DateTime startDate, int nightsCount);

        IEnumerable<Room> ExtractItemsFromCookie(HttpCookie cookie);

        HttpCookie DeleteItemFromCookie(HttpCookie cookie, string roomId);

        HttpCookie GetClearedCookie(string email);
    }
}
