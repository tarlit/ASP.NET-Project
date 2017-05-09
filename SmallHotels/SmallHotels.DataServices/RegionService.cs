using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using SmallHotels.DataServices.Contracts;
using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;

namespace SmallHotels.DataServices
{
    public class RegionService : IRegionService
    {
        private readonly IEfDbSetWrapper<Region> regionSetWrapper;

        private readonly IDbContextSaveChanges dbContext;
        
        public RegionService(IEfDbSetWrapper<Region> regionSetWrapper, IDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(regionSetWrapper, "regionSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.regionSetWrapper = regionSetWrapper;
            this.dbContext = dbContext;
        }
        
        //public IEnumerable<RegionModel> GetAllRegionsSortedById()
        //{
        //    return this.regionSetWrapper.All.ToList()
        //        .OrderBy(r => r.Id).AsQueryable()
        //        .Select(RegionModel.Create).ToList();
        //}

        //public IEnumerable<RegionModel> GetAllRegionsWithHotelsIncluded()
        //{
        //    return this.regionSetWrapper.AllWithInclude(r => r.Hotels)
        //        .Select(RegionModel.Create).ToList();
        //}

        //public RegionModel GetById(Guid id)
        //{
        //    return new RegionModel(this.regionSetWrapper.GetById(id));
        //}
    }
}