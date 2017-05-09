namespace SmallHotels.Common.Contracts
{
    public interface IUtilitiesService
    {
        T AssignModelParams<T>(T model, string query, int currentPage, int pagesCount, string baseUrl) where T : IPageable;

        int GetPage(int? page, int pagesCount);

        int? ExtractPage(string query);

        string ExtractSearchQuery(string query);
    }
}
