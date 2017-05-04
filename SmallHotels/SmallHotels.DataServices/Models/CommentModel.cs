using SmallHotels.Auth.Models;
using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.DataServices.Models
{
    public class CommentModel
    {
        public CommentModel()
        {
        }

        public CommentModel(Comment comment)
        {
            this.Id = comment.Id;
            this.Content = comment.Content;
            this.CreatedOn = comment.CreatedOn;
            if (comment.User != null)
            {
                this.UserId = comment.UserId;
            }

            if (comment.HotelInfo != null)
            {
                this.HotelInfoId = comment.HotelInfo.Id;
            }
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUserModel User { get; set; }

        public Guid HotelInfoId { get; set; }

        public HotelInfoModel HotelInfo { get; set; }


        public static Expression<Func<Comment, CommentModel>> Create
        {
            get
            {
                return comment => new CommentModel()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedOn = comment.CreatedOn
                };
            }
        }
    }
}
