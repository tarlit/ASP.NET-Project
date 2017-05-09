using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.Common.Contracts
{
    public interface IPageable
    {
        string BaseUrl { get; set; }

        int CurrentPage { get; set; }

        int PreviousPage { get; set; }

        int NextPage { get; set; }

        int PagesCount { get; set; }

        string Query { get; set; }
    }
}
