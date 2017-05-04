using Bytes2you.Validation;
using SmallHotels.DataServices.Contracts;
using SmallHotels.DataServices.Models;
using SmallHotels.Infrastructure;
using SmallHotels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallHotels.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IRegionService regionService;

        public HotelController(IHotelService hotelService, IRegionService regionService)
        {
            Guard.WhenArgument(hotelService, "hotelService").IsNull().Throw();
            Guard.WhenArgument(regionService, "regionService").IsNull().Throw();

            this.hotelService = hotelService;
            this.regionService = regionService;
        }

        public ActionResult Details(Guid? id)
        {
            HotelModel hotel = this.hotelService.GetById(id);

            HotelViewModel viewModel = new HotelViewModel(hotel);

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult All()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AllHotels()
        {
            var allRegionViewModels = this.regionService.GetAllRegionsWithHotelsIncluded()
                                            .Select(c => new RegionViewModel(c)).ToList();

            return this.PartialView("_AllHotelsPartial", allRegionViewModels);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult FilteredHotels(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return this.AllHotels();
            }
            else
            {
                var filteredHotels = this.hotelService.GetHotelsByName(searchTerm).Select(b => new HotelViewModel(b)).ToList();

                return this.PartialView("_FilteredHotelsPartial", filteredHotels);
            }
        }
    }
}