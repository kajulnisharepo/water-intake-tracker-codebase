using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace WaterIntakeTracker.Models
{
    public class ApiResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception exception){
            ApiResponse apiResponse= new ApiResponse();
            apiResponse.code = "1";
            apiResponse.message = exception.Message;
            return apiResponse;
        }

        public static ApiResponse GetAppResponse(ApiResponseType apiResponseType, object? contract){
            ApiResponse apiResponse;
             apiResponse = new ApiResponse(){ApiResponsedata = contract};
             switch (apiResponseType)
             {
                case ApiResponseType.Success:
                    apiResponse.code = "0";
                    apiResponse.message = "Success";
                    break;
                case ApiResponseType.NotFound:
                    apiResponse.code = "2";
                    apiResponse.message = "No Records Found";
                    break;
             }
            return apiResponse;
        }
    }
}