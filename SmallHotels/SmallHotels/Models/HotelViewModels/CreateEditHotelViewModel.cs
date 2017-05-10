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
    public class CreateEditHotelViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [EmailAddress]
        [Display(Name = "Hotel Email")]
        public string Email { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 30)]
        public string Description { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Location { get; set; }

        [StringLength(25, MinimumLength = 6)]
        public string Lattitude { get; set; }

        [StringLength(25, MinimumLength = 6)]
        public string Longitude { get; set; }

        public string Region { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Hotel, CreateEditHotelViewModel>()
                .ForMember(dest => dest.Region, s => s.MapFrom(src => src.Region.Name));
        }
    }
}