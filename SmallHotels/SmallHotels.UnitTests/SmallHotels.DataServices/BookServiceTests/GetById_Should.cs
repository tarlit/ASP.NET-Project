using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using SmallHotels.DataServices;
using SmallHotels.DataServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.UnitTests.SmallHotels.DataServices.BookServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        [TestMethod]
        public void ReturnModel_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ISmallHotelsEfDbContextSaveChanges>();
            Guid? bookId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(bookId.Value)).Returns(new Book() { Id = bookId.Value });

            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Act
            BookModel bookModel = bookService.GetById(bookId);

            // Assert
            Assert.IsNotNull(bookModel);
        }

        [TestMethod]
        public void ReturnNull_WhenIdIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ISmallHotelsEfDbContextSaveChanges>();
            
            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Act
            BookModel bookModel = bookService.GetById(null);

            // Assert
            Assert.IsNull(bookModel);
        }

        [TestMethod]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ISmallHotelsEfDbContextSaveChanges>();
            Guid? bookId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(bookId.Value)).Returns((Book)null);

            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Act
            BookModel bookModel = bookService.GetById(bookId);

            // Assert
            Assert.IsNull(bookModel);
        }
    }
}