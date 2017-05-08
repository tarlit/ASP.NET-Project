using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallHotels.Models
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
        }

        public CommentViewModel(CommentModel comment)
        {
            if (comment != null)
            {
                this.Id = comment.Id;
                this.Content = comment.Content;
                this.CreatedOn = comment.CreatedOn;
            }
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}