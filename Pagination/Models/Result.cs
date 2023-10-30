namespace Pagination.Models
{
    public class Result<T> where T : class
    {
        public T? Data { get; set; }
        public PageInfo? PageInfo { get; set; }

        public Result() { }
        public Result(T data, PageInfo pageInfo)
        {
            Data = data;
            PageInfo = pageInfo;
        }
    }
}
