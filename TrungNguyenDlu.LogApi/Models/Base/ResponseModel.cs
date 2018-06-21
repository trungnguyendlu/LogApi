using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungNguyenDlu.LogApi.Models.Base
{
    [Serializable]
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ResponseModel<T> SuccessResponse(T data, string message)
        {
            return new ResponseModel<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static ResponseModel<T> FailResponse(T data, string message)
        {
            return new ResponseModel<T>
            {
                Success = false,
                Data = data,
                Message = message
            };
        }
    }
}