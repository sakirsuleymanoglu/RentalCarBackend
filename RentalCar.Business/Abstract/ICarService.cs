﻿using System;
using System.Collections.Generic;
using System.Text;
using RentalCar.Core.Utilities.Results;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrand(int brandId);
        IDataResult<List<Car>> GetAllByColor(int colorId);
        IDataResult<List<Car>> GetAllByModelYear(string modelYear);
        IDataResult<List<Car>> GetAllByModel(string model);
        IDataResult<Car> Get(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
