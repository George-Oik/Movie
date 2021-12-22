using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Response
{
    /// <summary>
    /// To handle reporting the results the same way everywhere.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        public T Data { get; set; }
        public string ErrorText { get; set; }
        public StatusCode ErrorCode { get; set; }
        public bool Success => ErrorCode == StatusCode.OK;

        public static Result<T> ActionSuccessful(T data)
        {
            return new Result<T>
            {
                ErrorCode = StatusCode.OK,
                Data = data
            };
        }

        public static Result<T> ActionFailed(StatusCode code,
            string text)
        {
            return new Result<T>
            {
                ErrorCode = code,
                ErrorText = text
            };
        }
    }
}
