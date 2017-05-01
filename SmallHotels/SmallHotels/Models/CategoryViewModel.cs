using SmallHotels.DataServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmallHotels.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
        }

        public CategoryViewModel(CategoryModel category)
        {
            this.Name = category.Name;
            this.Books = category.Books.Select(b => new BookViewModel(b)).ToList();
        }

        public string Name { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}