using SmallHotels.Data.Models;
using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallHotels.DataServices.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAllCategoriesWithBooksIncluded();

        IEnumerable<CategoryModel> GetAllCategoriesSortedById();

        CategoryModel GetById(Guid id);
    }
}