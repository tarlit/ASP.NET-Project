using Bytes2you.Validation;
using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using SmallHotels.DataServices.Contracts;
using SmallHotels.DataServices.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SmallHotels.DataServices
{
    public class BookService : IBookService
    {
        private readonly IEfDbSetWrapper<Hotel> bookSetWrapper;

        private readonly ISmallHotelsEfDbContextSaveChanges dbContext;

        public BookService(IEfDbSetWrapper<Hotel> bookSetWrapper, ISmallHotelsEfDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(bookSetWrapper, "bookSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.bookSetWrapper = bookSetWrapper;
            this.dbContext = dbContext;
        }

        public BookModel GetById(Guid? id)
        {
            BookModel result = null;

            if (id.HasValue)
            {
                Hotel book = this.bookSetWrapper.GetById(id.Value);
                if (book != null)
                {
                    result = new BookModel(book);
                }
            }

            return result;
        }

        public IEnumerable<BookModel> GetBooksByTitleOrAuthor(string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? this.bookSetWrapper.All.Select(BookModel.Create).ToList()
                : this.bookSetWrapper.All
                    .Where(b =>
                        (string.IsNullOrEmpty(b.Name) ? false : b.Name.Contains(searchTerm))
                        ||
                        (string.IsNullOrEmpty(b.Author) ? false : b.Author.Contains(searchTerm)))
                    .Select(BookModel.Create).ToList();
        }

        // TODO - GetBookByTitle, GetBookByAuthor
    }
}