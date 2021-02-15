using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            User user = new User
            {
                FirstName = "Şakir",
                LastName = "Süleymanoğlu",
            };

            User user2 = new User
            {
                FirstName = "Ramazan",
                LastName = "Ayaz",
            };

            User user3 = new User
            {
                FirstName = "Enes",
                LastName = "Ayaz",
            };


            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(user);
            userManager.Add(user2);
            userManager.Add(user3); 

            Customer customer = new Customer
            {
                UserId = 1,
                CompanyName = "Süleymanoğlu"
            };

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(customer); */

            //Rental rental = new Rental
            //{
            //    CarId = 1,
            //    CustomerId = 1,
            //    RentDate = Convert.ToDateTime("15.02.2021 00:00")
            //};

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //var result = rentalManager.Add(rental);

            //if (result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            //Rental rental = new Rental
            //{
            //    CarId = 1,
            //    CustomerId = 1,
            //    RentDate = Convert.ToDateTime("15.02.2021"),
            //    ReturnDate = Convert.ToDateTime("16.02.2021")
            //};

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //var result = rentalManager.Add(rental);

            //if (result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }
    }
}
