using SmallHotels.Common.Contracts;
using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SmallHotels.Models.HotelViewModels
{
    public class CommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Content")]
        public string CommentContent { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentsViewModel>()
                .ForMember(dest => dest.Author, s => s.MapFrom(src => src.User.Email));
        }
    }
}