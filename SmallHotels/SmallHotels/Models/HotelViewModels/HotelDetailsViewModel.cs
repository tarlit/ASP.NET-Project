using SmallHotels.Common.Contracts;
using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace SmallHotels.Models.HotelViewModels
{
    public class HotelDetailsViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Lattitude { get; set; }

        public string Longitude { get; set; }

        public bool IsHotelLiked { get; set; }

        public string Region { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Comment> Likes { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Hotel, HotelDetailsViewModel>()
                .ForMember(dest => dest.Region, s => s.MapFrom(src => src.Region.Name));
        }
    }
}