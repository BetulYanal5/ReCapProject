using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandService _brandService;
        public BrandManager(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public void Add(Brand brand)
        {
            _brandService.Add(brand);
            
        }

        public void Delete(Brand brand)
        {
            _brandService.Delete(brand);
        }

        public List<Brand> GetAllBrands()
        {
            return _brandService.GetAllBrands();
        }

        public void Update(Brand brand)
        {
            _brandService.Update(brand);
        }
    }
}
