using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using SmallHotels.DataServices.Contracts;
using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using SmallHotels.DataServices.Factories;
using SmallHotels.Common.Constants;

namespace SmallHotels.DataServices
{
    public class RegionService : IRegionService
    {
        private readonly IEfDbSetWrapper<Region> regionSetWrapper;
        private readonly IDbContextSaveChanges dbContext;
        private readonly IRegionFactory regionFactory;

        public RegionService(IEfDbSetWrapper<Region> regionSetWrapper, IDbContextSaveChanges dbContext, IRegionFactory regionFactory)
        {
            Guard.WhenArgument(regionSetWrapper, "regionSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();
            Guard.WhenArgument(regionFactory, "regionFactory").IsNull().Throw();

            this.regionSetWrapper = regionSetWrapper;
            this.dbContext = dbContext;
            this.regionFactory = regionFactory;
        }

        public IEnumerable<Region> GetAllRegionsWithHotelsIncluded()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Region> GetAllRegionsSortedById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Region> GetAllRegionsSortedByName()
        {
            throw new NotImplementedException();
        }

        public Region GetById(Guid? id)
        {
            Region result = null;

            if (id.HasValue)
            {
                Region region = this.regionSetWrapper.GetById(id.Value);
                if (region != null)
                {
                    return region;
                }
            }

            return result;
        }

        public void CreateRegion(string name)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();

            Region region = this.regionFactory.CreateRegion(name);
            this.regionSetWrapper.Add(region);
            this.dbContext.SaveChanges();
        }

        public void DeleteRegion(Guid? id)
        {
            if (id.HasValue)
            {
                Region region = this.regionSetWrapper.GetById(id.Value);
                if (region != null)
                {
                    this.regionSetWrapper.Delete(region);
                    this.dbContext.SaveChanges();
                }
            }
        }

        public int GetPagesCount(string query)
        {
            int regionsCount;
            if (!string.IsNullOrEmpty(query))
            {
                regionsCount = this.regionSetWrapper.All
                    .Where(x => (x.Name.ToLower().Contains(query.ToLower()))).ToList()
                    .Count();
            }
            else
            {
                regionsCount = this.regionSetWrapper.All.ToList()
                    .Count();
            }

            int pagesCount;
            if (regionsCount == 0)
            {
                pagesCount = 1;
            }
            else
            {
                pagesCount = (int)Math.Ceiling((decimal)regionsCount / PageConstants.RegionsPageSize);
            }

            return pagesCount;
        }

        public IEnumerable<Region> GetRegionsByPage(string query, int page, int pageSize)
        {
            var regions = new List<Region>();
            if (!string.IsNullOrEmpty(query))
            {
                regions = this.regionSetWrapper.AllWithInclude(r => r.Hotels)
                     .Where(x => (x.Name.ToLower().Contains(query.ToLower())))
                     .ToList()
                     .OrderByDescending(x => x.Name).AsQueryable()
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
            }
            else
            {
                regions = this.regionSetWrapper.AllWithInclude(r => r.Hotels)
                     .ToList()
                     .OrderByDescending(x => x.Name).AsQueryable()
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
            }

            return regions;
        }
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
    //}
}