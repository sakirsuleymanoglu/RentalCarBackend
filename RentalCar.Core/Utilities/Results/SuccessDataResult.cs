using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Utilities.Results
{
    public class SuccessDataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }

        public SuccessDataResult() : base(true)
        {

        }

        public SuccessDataResult(T data) : base(true)
        {
            Data = data;
        }

        public SuccessDataResult(T data, string message) : base(true, message)
        {
            Data = data;
        }
    }
}
