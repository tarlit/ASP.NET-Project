using SmallHotels.Common.Contracts;
using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SmallHotels.Models.RegionViewModels
{
    public class RegionItemViewModel : IMapFrom<Region>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int HotelsCount { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Region, RegionItemViewModel>()
                .ForMember(dest => dest.HotelsCount, s => s.MapFrom(src => src.Hotels.Count));
        }
    }
}