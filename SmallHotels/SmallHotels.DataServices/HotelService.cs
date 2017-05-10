using Bytes2you.Validation;
using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using SmallHotels.DataServices.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using SmallHotels.DataServices.Factories;

namespace SmallHotels.DataServices
{
    public class HotelService : IHotelService
    {
        private readonly IEfDbSetWrapper<Hotel> hotelSetWrapper;
        private readonly IDbContextSaveChanges dbContext;
        private readonly IHotelFactory hotelFactory;
        private readonly ICommentFactory commentFactory;
        private readonly ILikeFactory likeFactory;

        public HotelService(IEfDbSetWrapper<Hotel> hotelSetWrapper, IDbContextSaveChanges dbContext, IHotelFactory hotelFactory, ICommentFactory commentFactory, ILikeFactory likeFactory)
        {
            Guard.WhenArgument(hotelSetWrapper, "hotelSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(hotelFactory, "hotelFactory").IsNull().Throw();
            Guard.WhenArgument(commentFactory, "commentFactory").IsNull().Throw();
            Guard.WhenArgument(likeFactory, "likeFactory").IsNull().Throw();

            this.hotelSetWrapper = hotelSetWrapper;
            this.dbContext = dbContext;
            this.hotelFactory = hotelFactory;
            this.commentFactory = commentFactory;
            this.likeFactory = likeFactory;
        }

        public Hotel GetById(Guid? id)
        {
            Hotel result = null;

            if (id.HasValue)
            {
                Hotel hotel = this.hotelSetWrapper.GetById(id.Value);
                if (hotel != null)
                {
                    return hotel;
                }
            }

            return result;
        }

        public IEnumerable<Hotel> GetHotelsByName(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetHotelsByRegion(Guid regionId)
        {
            throw new NotImplementedException();
        }

        public void CreateHotel(string name, string email, string imageUrl, string description, string location, string lattitude, string longitude, Guid regionId)
        {
            throw new NotImplementedException();
        }

        public void EditHotel(Guid hotelId, string name, string email, string imageUrl, string description)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotel(Guid hotelId)
        {
            throw new NotImplementedException();
        }

        public int GetPagesCount(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetHotelsByPage(string query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void AddComment(Guid hotelId, string userId, string content)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public void ToggleLike(Guid hotelId, string userId)
        {
            throw new NotImplementedException();
        }

        public bool IsHotelLiked(Guid hotelId, string userId)
        {
            throw new NotImplementedException();
        }
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
    //}
}