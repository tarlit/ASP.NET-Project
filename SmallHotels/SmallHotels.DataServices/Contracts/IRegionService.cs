using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallHotels.DataServices.Contracts
{
    public interface IRegionService
    {
        IEnumerable<Region> GetAllRegionsWithHotelsIncluded();

        IEnumerable<Region> GetAllRegionsSortedById();

        IEnumerable<Region> GetAllRegionsSortedByName();

        Region GetById(Guid? id);

        void CreateRegion(string name);

        void DeleteRegion(Guid? regionId);

        int GetPagesCount(string query);

        IEnumerable<Region> GetRegionsByPage(string query, int page, int pageSize);
    }
}