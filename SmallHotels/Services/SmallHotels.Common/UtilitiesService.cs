using SmallHotels.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.Common
{
    public class UtilitiesService : IUtilitiesService
    {
        public T AssignModelParams<T>(T model, string query, int currentPage, int pagesCount, string baseUrl) 
            where T : IPageable
        {
            model.Query = query;
            model.CurrentPage = currentPage;
            model.PreviousPage = currentPage - 1;
            model.NextPage = currentPage + 1;
            model.PagesCount = pagesCount;
            model.BaseUrl = baseUrl;

            return model;
        }

        public int? ExtractPage(string query)
        {
            if (query == null)
            {
                return null;
            }

            var queryParams = query.Split('?', '&')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Trim()).ToList();

            var pageQuery = queryParams.FirstOrDefault(x => x.Contains("page"));
            if (pageQuery == null)
            {
                return null;
            }

            int page;
            var isParsable = int.TryParse(pageQuery.Split('=').ToList().Last(), out page);
            if (page == 0)
            {
                return null;
            }

            return page;
        }

        public string ExtractSearchQuery(string query)
        {
            if (query == null)
            {
                return null;
            }

            var queryParams = query.Split('?', '&')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Trim()).ToList();

            var searchQuery = queryParams.FirstOrDefault(x => x.Contains("query"));
            if (searchQuery == null)
            {
                return null;
            }

            var result = searchQuery.Split('=').ToList().Last();

            return result;
        }

        public int GetPage(int? page, int pagesCount)
        {
            int result;
            if (page == null || page < 1 || page > pagesCount)
            {
                result = 1;
            }
            else
            {
                result = (int)page;
            }

            return result;
        }
    }
}
