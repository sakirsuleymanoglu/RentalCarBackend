using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool succes)
        {
            Success = succes;
        }

        public Result(bool succes, string message) : this(succes)
        {
            Message = message;
        }
    }
}
