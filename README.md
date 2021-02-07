# KatmanliMimariArabaKiralama
C# katmanlı mimari ile araba kiralama uygulaması


            
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            foreach (var car in result)
            {
                Console.WriteLine("Brand Name : " + car.BrandName + " " + "Color : " + car.ColorName + " " + "Daily Price : " + car.DailyPrice);
            }
