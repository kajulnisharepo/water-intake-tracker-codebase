using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterIntakeTracker.Models
{
    public class ApiResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public object? ApiResponsedata { get; set; }
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
