using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>//Car nesnemiz için veritabanı katmanında interface'ni oluşturduk ve operasyonları ekledik
    {
        List<CarDetailDto> GetCarDetails();
    }
}
