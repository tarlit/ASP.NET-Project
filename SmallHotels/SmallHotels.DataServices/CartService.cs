using SmallHotels.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallHotels.Data.Models;
using System.Web;

namespace SmallHotels.DataServices
{
    public class CartService : ICartService
    {
        public HttpCookie DeleteItemFromCookie(HttpCookie cookie, string roomId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> ExtractItemsFromCookie(HttpCookie cookie)
        {
            throw new NotImplementedException();
        }

        public HttpCookie GetClearedCookie(string email)
        {
            throw new NotImplementedException();
        }

        public HttpCookie WriteCookie(HttpCookie cookie, string email, string roomId, DateTime startDate, int nightsCount)
        {
            throw new NotImplementedException();
        }
    }
}
