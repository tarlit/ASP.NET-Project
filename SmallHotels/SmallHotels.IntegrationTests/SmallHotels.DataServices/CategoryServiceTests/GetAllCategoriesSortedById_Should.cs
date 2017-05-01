using SmallHotels.App_Start;
using SmallHotels.Data;
using SmallHotels.Data.Models;
using SmallHotels.DataServices.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.IntegrationTests.SmallHotels.DataServices.CategoryServiceTests
{
    [TestClass]
    public class GetAllCategoriesSortedById_Should
    {
        //private static List<Category> dbCategories = new List<Data.Models.Category>() {
        //    new Category()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "category 1"
        //    },
        //    new Category()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "category 2"
        //    },
        //    new Category()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "category 3"
        //    }
        //};

        //private static Book dbBook = new Book()
        //{
        //    Id = Guid.NewGuid(),
        //    Author = "author",
        //    Description = "description",
        //    ISBN = "ISBN",
        //    Title = "title",
        //    WebSite = "website"
        //};

        //private static IKernel kernel;

        //[TestInitialize]
        //public void TestInit()
        //{
        //    kernel = NinjectWebCommon.CreateKernel();
        //    SmallHotelsEfDbContext dbContext = kernel.Get<SmallHotelsEfDbContext>();

        //    foreach (Category dbCategory in dbCategories)
        //    {
        //        dbContext.Categories.Add(dbCategory);
        //    }

        //    dbContext.SaveChanges();

        //    var category = dbContext.Categories.First();
        //    dbBook.CategoryId = category.Id;
        //    dbBook.Category = category;

        //    dbContext.Books.Add(dbBook);
        //    dbContext.SaveChanges();
        //}

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    SmallHotelsEfDbContext dbContext = kernel.Get<SmallHotelsEfDbContext>();
            
        //    foreach (Category dbCategory in dbCategories)
        //    {
        //        dbContext.Categories.Attach(dbCategory);
        //        dbContext.Categories.Remove(dbCategory);
        //    }

        //    dbContext.SaveChanges();
        //}

        //[TestMethod]
        //public void ReturnAllCategoriesSortedById()
        //{
        //    // Arrange
        //    ICategoryService categoryService = kernel.Get<ICategoryService>();

        //    var expectedOrder = dbCategories.OrderBy(c => c.Id).ToList();

        //    // Act
        //    var result = categoryService.GetAllCategoriesSortedById().ToList();

        //    // Assert
        //    for (int i = 0; i < expectedOrder.Count; i++)
        //    {
        //        Assert.AreEqual(expectedOrder[i].Id, result[i].Id);
        //    }
        //}
    }
}
