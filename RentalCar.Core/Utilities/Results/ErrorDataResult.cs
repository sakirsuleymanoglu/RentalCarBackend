using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Utilities.Results
{
    public class ErrorDataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }

        public ErrorDataResult() : base(false)
        {

        }

        public ErrorDataResult(string message) : base(false, message)
        {

        }

        public ErrorDataResult(T data) : base(false)
        {
            Data = data;
        }

        public ErrorDataResult(T data, string message) : base(false, message)
        {
            Data = data;
        }
    }
}
