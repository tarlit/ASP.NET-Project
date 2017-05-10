using Bytes2you.Validation;
using SmallHotels.Common.Contracts;
using SmallHotels.DataServices.Contracts;
using SmallHotels.Infrastructure;
using SmallHotels.Models;
using SmallHotels.Models.HotelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallHotels.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        protected readonly IHotelService hotelService;
        protected readonly IMappingService mappingService;
        protected readonly IUserInfoService userInfoService;
        protected readonly IUtilitiesService utils;

        public HotelController(IHotelService hotelService, IMappingService mappingService, IUserInfoService userInfoService, IUtilitiesService utils)
        {
            Guard.WhenArgument(hotelService, "hotelService").IsNull().Throw();
            Guard.WhenArgument(mappingService, "mappingService").IsNull().Throw();
            Guard.WhenArgument(userInfoService, "userInfoService").IsNull().Throw();
            Guard.WhenArgument(utils, "utils").IsNull().Throw();

            this.hotelService = hotelService;
            this.mappingService = mappingService;
            this.userInfoService = userInfoService;
            this.utils = utils;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateHotel()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]     
        public ActionResult CreateHotel(CreateEditHotelViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.hotelService.CreateHotel(model.Name, model.Email, model.ImageUrl, model.Description, model.Location, model.Lattitude, model.Longitude, model.Region);

            return this.RedirectToAction("Index");
        }

        //[HttpGet]
        //[ChildActionOnly]
        //public ActionResult AllHotels()
        //{
        //    var allRegionViewModels = this.regionService.GetAllRegionsWithHotelsIncluded()
        //                                    .Select(c => new RegionViewModel(c)).ToList();

        //    return this.PartialView("_AllHotelsPartial", allRegionViewModels);
        //}

        //[HttpPost]
        //[AjaxOnly]
        //public ActionResult FilteredHotels(string searchTerm)
        //{
        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        return this.AllHotels();
        //    }
        //    else
        //    {
        //        var filteredHotels = this.hotelService.GetHotelsByName(searchTerm).Select(b => new HotelViewModel(b)).ToList();

        //        return this.PartialView("_FilteredHotelsPartial", filteredHotels);
        //    }
        //}
    }
}