using SmallHotels.Common.Contracts;
using SmallHotels.Data.Models;
using System;
using AutoMapper;

namespace SmallHotels.Models.HotelViewModels
{
    public class HotelItemViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Region { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public int RoomsCount { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Hotel, HotelItemViewModel>()
                .ForMember(dest => dest.Region, s => s.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.LikesCount, s => s.MapFrom(src => src.Likes.Count))
                .ForMember(dest => dest.CommentsCount, s => s.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.RoomsCount, s => s.MapFrom(src => src.Rooms.Count));
        }
    }
}