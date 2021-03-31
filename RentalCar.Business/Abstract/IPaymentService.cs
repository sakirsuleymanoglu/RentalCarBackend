using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(decimal price, CreditCard creditCard);
        IDataResult<CreditCard> GetByCreditCardNumber(string creditCardNumber);
        IDataResult<CreditCard> GetByCreditCardCustomerId(int creditCardNumber);
    }
}
