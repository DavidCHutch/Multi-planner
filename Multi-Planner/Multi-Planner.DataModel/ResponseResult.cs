using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel
{
    public enum ServiceResponseStatus
    {
        Ok,
        NotFound,
        InvalidRequest,
        Error
    }

    public struct ServiceResponse<T>
    {
        public ServiceResponse(ServiceResponseStatus status, string message, T result)
        {
            Status = status;
            Message = message;
            Result = result;
        }

        public ServiceResponse(ServiceResponseStatus status, T result)
        {
            Status = status;
            Message = "";
            Result = result;
        }

        public ServiceResponse(ServiceResponseStatus status)
        {
            Status = status;
            Message = "";
            Result = default(T);
        }

        public ServiceResponseStatus Status { get; }
        public string Message { get; }
        public T Result { get; }
    }
}
