using PMSv1_Shared.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSv1_Shared.Helpers
{
    public static class ExceptionHandler
    {
        public static ApiResponse Handle(Exception e)
        {
            return new ApiResponse
            {
                StatusCode = 500,
                Message = e.Message,
                IsSuccess = false
            };
        }
        public static ApiResponse<T> Handle<T>(Exception e)
        {
            return new ApiResponse<T>
            {
                StatusCode = 500,
                Message = e.Message,
                IsSuccess = false,
                Result = default!
            };
        }
    }
}
