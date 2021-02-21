using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
