using System;

namespace TextAnalyzer.Entities.Exceptions
{
    public class BaseException : ApplicationException
    {
        public ErrorCodeEnum ErrorCode { get; set; }

        public BaseException(ErrorCodeEnum errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
