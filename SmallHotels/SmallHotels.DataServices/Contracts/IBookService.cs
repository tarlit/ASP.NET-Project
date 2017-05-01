using SmallHotels.DataServices.Models;
using System;
using System.Collections.Generic;

namespace SmallHotels.DataServices.Contracts
{
    public interface IBookService
    {
        BookModel GetById(Guid? id);

        IEnumerable<BookModel> GetBooksByTitleOrAuthor(string searchTerm);
    }
}