using Bytes2you.Validation;
using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using SmallHotels.DataServices.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SmallHotels.DataServices
{
    public class HotelService : IHotelService
    {
        private readonly IEfDbSetWrapper<Hotel> hotelSetWrapper;

        private readonly IDbContextSaveChanges dbContext;

        public HotelService(IEfDbSetWrapper<Hotel> hotelSetWrapper, IDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(hotelSetWrapper, "hotelSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.hotelSetWrapper = hotelSetWrapper;
            this.dbContext = dbContext;
        }

        //public HotelModel GetById(Guid? id)
        //{
        //    HotelModel result = null;

        //    if (id.HasValue)
        //    {
        //        Hotel hotel = this.hotelSetWrapper.GetById(id.Value);
        //        if (hotel != null)
        //        {
        //            result = new HotelModel(hotel);
        //        }
        //    }

        //    return result;
        //}

        //public IEnumerable<HotelModel> GetHotelsByName(string searchTerm)
        //{
        //    return string.IsNullOrEmpty(searchTerm)
        //        ? this.hotelSetWrapper.All.Select(HotelModel.Create).ToList()
        //        : this.hotelSetWrapper.All
        //            .Where(h =>
        //                (string.IsNullOrEmpty(h.Name) ? false : h.Name.Contains(searchTerm)))
        //            .Select(HotelModel.Create).ToList();
        //}
    }
}