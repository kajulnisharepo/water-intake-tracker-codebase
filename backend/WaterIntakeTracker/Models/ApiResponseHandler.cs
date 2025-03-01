using System;

namespace WaterIntakeTracker.Models
{
    public class ApiResponseHandler
    {
        public static ApiResponse<object> GetExceptionResponse(Exception exception)
        {
            var apiResponse = new ApiResponse<object>
            {
                Code = "1",
                Message = exception.Message,
                Data = null
            };
            return apiResponse;
        }

        public static ApiResponse<T> GetAppResponse<T>(ApiResponseType apiResponseType, T? data)
        {
            var apiResponse = new ApiResponse<T>
            {
                Data = data
            };

            switch (apiResponseType)
            {
                case ApiResponseType.Success:
                    apiResponse.Code = "0";
                    apiResponse.Message = "Success";
                    break;
                case ApiResponseType.NotFound:
                    apiResponse.Code = "2";
                    apiResponse.Message = "No Records Found";
                    break;
            }

            return apiResponse;
        }
    }
}
