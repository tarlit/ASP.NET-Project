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
        private readonly IRoomFactory roomFactory;
        private readonly ICommentFactory commentFactory;
        private readonly ILikeFactory likeFactory;

        public HotelService(IEfDbSetWrapper<Hotel> hotelSetWrapper, IDbContextSaveChanges dbContext, IHotelFactory hotelFactory, IRoomFactory roomFactory, ICommentFactory commentFactory, ILikeFactory likeFactory)
        {
            Guard.WhenArgument(hotelSetWrapper, "hotelSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(hotelFactory, "hotelFactory").IsNull().Throw();
            Guard.WhenArgument(roomFactory, "roomFactory").IsNull().Throw();
            Guard.WhenArgument(commentFactory, "commentFactory").IsNull().Throw();
            Guard.WhenArgument(likeFactory, "likeFactory").IsNull().Throw();

            this.hotelSetWrapper = hotelSetWrapper;
            this.dbContext = dbContext;
            this.hotelFactory = hotelFactory;
            this.roomFactory = roomFactory;
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

        public void CreateHotel(string name, string email, string imageUrl, string description, string location, string lattitude, string longitude, string region)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();
            Guard.WhenArgument(email, "email").IsNull().Throw();
            Guard.WhenArgument(imageUrl, "imageUrl").IsNull().Throw();
            Guard.WhenArgument(description, "description").IsNull().Throw();
            Guard.WhenArgument(location, "location").IsNull().Throw();
            Guard.WhenArgument(lattitude, "lattitude").IsNull().Throw();
            Guard.WhenArgument(longitude, "longitude").IsNull().Throw();
            if (region == null)
            {
                throw new ArgumentNullException("Region Name cannot be null or empty!");
            }

            Hotel hotel = this.hotelFactory.CreateHotel(name, email, imageUrl, description, location, lattitude, longitude, region);
            this.hotelSetWrapper.Add(hotel);
            this.dbContext.SaveChanges();
        }

        public void EditHotel(Guid hotelId, string name, string email, string imageUrl, string description)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotel(Guid? id)
        {
            if (id.HasValue)
            {
                Hotel hotel = this.hotelSetWrapper.GetById(id.Value);
                if (hotel != null)
                {
                    this.hotelSetWrapper.Delete(hotel);
                    this.dbContext.SaveChanges();
                }
            }
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
            Guard.WhenArgument(userId, "userId").IsNull().Throw();
            Guard.WhenArgument(content, "content").IsNull().Throw();

            // TODO
        }

        public void DeleteComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public void ToggleLike(Guid hotelId, string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            Hotel hotel = this.hotelSetWrapper.GetById(hotelId);
            var like = hotel.Likes.FirstOrDefault(x => x.UserId == userId);

            if (like != null)
            {
                hotel.Likes.Remove(like);
            }
            else
            {
                like = this.likeFactory.CreateLike(userId, hotelId);
                hotel.Likes.Add(like);
            }

            this.dbContext.SaveChanges();
        }

        public bool IsHotelLiked(Guid hotelId, string userId)
        {
            Hotel hotel = this.hotelSetWrapper.GetById(hotelId);
            if (hotel.Likes.Any(x => x.UserId == userId))
            {
                return true;
            }

            return false;
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