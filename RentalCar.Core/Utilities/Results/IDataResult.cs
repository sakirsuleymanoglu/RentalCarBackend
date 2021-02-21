using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; set; }
    }
}
