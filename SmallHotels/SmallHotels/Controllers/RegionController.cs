using Bytes2you.Validation;
using SmallHotels.Common;
using SmallHotels.Common.Contracts;
using SmallHotels.DataServices.Contracts;
using SmallHotels.Models.RegionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SmallHotels.Common.Constants;

namespace SmallHotels.Controllers
{
    [Authorize]
    public class RegionController : Controller
    {
        protected readonly IRegionService regionService;
        protected readonly IMappingService mappingService;
        protected readonly IUserInfoService userInfoService;
        protected readonly IUtilitiesService utils;

        public RegionController(IRegionService regionService, IMappingService mappingService, IUserInfoService userInfoService, IUtilitiesService utils)
        {
            Guard.WhenArgument(regionService, "regionService").IsNull().Throw();
            Guard.WhenArgument(mappingService, "mappingService").IsNull().Throw();
            Guard.WhenArgument(userInfoService, "userInfoService").IsNull().Throw();
            Guard.WhenArgument(utils, "utils").IsNull().Throw();

            this.regionService = regionService;
            this.mappingService = mappingService;
            this.userInfoService = userInfoService;
            this.utils = utils;
        }

        [AllowAnonymous]
        public ActionResult Index(string query, int? page)
        {
            var pagesCount = this.regionService.GetPagesCount(query);
            var currentPage = this.utils.GetPage(page, pagesCount);
            var stories = this.regionService.GetRegionsByPage(query, currentPage, PageConstants.RegionsPageSize);
            var mappedRegions = this.mappingService.Map<IEnumerable<RegionItemViewModel>>(stories);
            var model = this.mappingService.Map<RegionsListViewModel>(mappedRegions);
            model = this.utils.AssignModelParams(model, query, currentPage, pagesCount, PageConstants.RegionsBaseUrl);

            return this.View(model);
        }
    }
}