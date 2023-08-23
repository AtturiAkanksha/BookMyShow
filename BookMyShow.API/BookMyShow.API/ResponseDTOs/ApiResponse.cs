using System.Net;

namespace BookMyShow.API.ResponseDTOs
{
    public class ApiResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Error { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            ApiResponse<T> apiResponse = new()
            {
                Data = data,
                IsSuccess = true,
                Status = HttpStatusCode.OK,
                Error = default
            };
            return apiResponse;
        }

        public static ApiResponse<T> Failure(string message)
        {
            ApiResponse<T> apiResponse = new()
            {
                Data = default,
                IsSuccess = false,
                Status = HttpStatusCode.BadRequest,
                Error = message
            };
            return apiResponse;
        }
    }
}
