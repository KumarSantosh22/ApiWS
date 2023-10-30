using System.Net;

namespace Pagination.Models
{
    public class APIResponse<T> where T : class
    {
        public bool IsSucceed { get; set; }
        public HttpStatusCode Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public PageInfo? PageInfo { get; set; }

        public static APIResponse<T> Success(T data, PageInfo pageInfo, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new APIResponse<T> { Data = data, PageInfo = pageInfo, IsSucceed = true, Status = statusCode };
        }

        public static APIResponse<T> Success(T data, PageInfo pageInfo,string message, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new APIResponse<T> { Data = data, PageInfo=pageInfo, IsSucceed = true, Status=statusCode, Message=message };
        }
        
        public static APIResponse<T> Failure(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new APIResponse<T> { IsSucceed = false, Status=statusCode, Message=message };
        }
    }
}
