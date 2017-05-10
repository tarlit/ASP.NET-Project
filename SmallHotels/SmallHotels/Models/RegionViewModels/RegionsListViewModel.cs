using SmallHotels.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SmallHotels.Models.RegionViewModels
{
    public class RegionsListViewModel : IMapFrom<IEnumerable<RegionItemViewModel>>, IHaveCustomMappings, IPageable
    {
        public IList<RegionItemViewModel> Regions { get; set; }

        public string BaseUrl { get; set; }

        public int CurrentPage { get; set; }

        public int NextPage { get; set; }

        public int PagesCount { get; set; }

        public int PreviousPage { get; set; }

        public string Query { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<IEnumerable<RegionItemViewModel>, RegionsListViewModel>()
                .ForMember(dest => dest.Regions, s => s.MapFrom(src => src));
        }
    }
}