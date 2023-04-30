using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Wrappers
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }


        public ServiceResponse(T value)
        {
            Value = value;
        }

        public ServiceResponse(Guid id, string message, T value) : base(id, message)
        {
            Value = value;
        }

        public ServiceResponse(Guid id, string message, bool isSuccess, T value) : base(id, message, isSuccess)
        {
            Value = value;
        }

    }
}
