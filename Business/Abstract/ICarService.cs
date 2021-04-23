using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService:ICrudService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int Id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int Id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car);
    }
}
