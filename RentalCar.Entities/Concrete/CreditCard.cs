using RentalCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string CardLastUseDate { get; set; }
        public string SecurityValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
    }
}
