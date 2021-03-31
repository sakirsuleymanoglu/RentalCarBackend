using RentalCar.Business.Abstract;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        ICreditCardDal _creditCardDal;

        public PaymentManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<CreditCard> GetByCreditCardCustomerId(int customerId)
        {
            var result = _creditCardDal.Get(c => c.CustomerId == customerId);

            if (result != null)
            {
                return new SuccessDataResult<CreditCard>(result);
            }

            return new ErrorDataResult<CreditCard>(result);
        }

        public IDataResult<CreditCard> GetByCreditCardNumber(string creditCardNumber)
        {
            var result = _creditCardDal.Get(c => c.CardNumber == creditCardNumber);

            if (result != null)
            {
                return new SuccessDataResult<CreditCard>(result);
            }

            return new ErrorDataResult<CreditCard>(result);

        }

        public IResult Pay(decimal price, CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckIfEXistCreditCard(creditCard.Id));

            if (result != null)
            {
                return result;
            }

            if (price > creditCard.Balance)
            {
                return new ErrorResult();
            }

            creditCard.Balance = creditCard.Balance - price;

            _creditCardDal.Update(creditCard);

            return new SuccessResult();
        }

        private IResult CheckIfEXistCreditCard(int creditCardId)
        {
            var result = _creditCardDal.Get(c => c.Id == creditCardId);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
