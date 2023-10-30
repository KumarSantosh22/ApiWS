namespace Pagination.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalResults { get; set; }
        public int TotalPages { get; set; } = 1;

        public PageInfo() { }

        public PageInfo(int pageNumber, int totalResults)
        {
            TotalResults = totalResults;
            TotalPages = (int)Math.Ceiling((double)totalResults / PageSize);
            PageNumber = pageNumber;
        }

        public PageInfo(int pageNumber, int pageSize, int totalResults)
        {
            PageSize = pageSize;
            TotalResults = totalResults;
            TotalPages = (int)Math.Ceiling((double)totalResults / pageSize);
            PageNumber = pageNumber;
        }
    }
}
