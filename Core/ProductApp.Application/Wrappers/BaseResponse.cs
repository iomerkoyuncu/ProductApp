using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Wrappers
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = true;

        public BaseResponse()
        {
        }

        public BaseResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }

        public BaseResponse(Guid id, string message, bool isSuccess)
        {
            Id = id;
            Message = message;
            IsSuccess = isSuccess;
        }

        public BaseResponse(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
