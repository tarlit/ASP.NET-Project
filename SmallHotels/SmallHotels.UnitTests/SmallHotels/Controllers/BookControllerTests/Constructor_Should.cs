using SmallHotels.Controllers;
using SmallHotels.DataServices.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.UnitTests.SmallHotels.Controllers.BookControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            //// Arrange
            //var bookServiceMock = new Mock<IBookService>();
            //var categoryServiceMock = new Mock<ICategoryService>();

            //// Act
            //BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

            //// Assert
            //Assert.IsNotNull(bookController);
        }

        [TestMethod]
        public void ThrowException_WhenParametersAreNull()
        {
            //// Arrange & Act & Assert
            //Assert.ThrowsException<ArgumentNullException>(() => new BookController(null, null));
        }
    }
}