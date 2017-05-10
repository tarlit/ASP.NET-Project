using SmallHotels.Common.Contracts;
using System.Collections.Generic;
using AutoMapper;

namespace SmallHotels.Models.HotelViewModels
{
    public class HotelsListViewModel : IMapFrom<IEnumerable<HotelItemViewModel>>, IHaveCustomMappings, IPageable
    {
        public IEnumerable<HotelItemViewModel> Hotels { get; set; }

        public string BaseUrl { get; set; }

        public int CurrentPage { get; set; }

        public int NextPage { get; set; }

        public int PagesCount { get; set; }

        public int PreviousPage { get; set; }

        public string Query { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<IEnumerable<HotelItemViewModel>, HotelsListViewModel>()
                .ForMember(dest => dest.Hotels, s => s.MapFrom(src => src));
        }
    }
}