using System;

namespace WaterIntakeTracker.Models
{
    public class ApiResponse<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ApiResponseType ResponseType { get; set; }

        public bool IsSuccess => ResponseType == ApiResponseType.Success;
    }

    public enum ApiResponseType
    {
        Success,
        NotFound,
        Failure
    }
}
