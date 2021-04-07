using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CustomerInfo = $"{u.FirstName} {u.LastName}",
                                 CompanyName =cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                //var result = from c in context.Cars
                //             join r in context.Rentals
                //             on c.Id equals r.CarId
                //             join b in context.Brands
                //             on c.BrandId equals b.BrandId
                //             join color in context.Colors
                //             on c.ColorId equals color.ColorId
                //             join cu in context.Customers
                //             on r.CustomerId equals cu.CustomerId
                //             join u in context.Users
                //             on cu.UserId equals u.UserId
                //             select new RentalDetailDto
                //             {
                //                BrandName = b.BrandName,                              
                //                CustomerInfo = $"{cu.CompanyName} {cu.CustomerId}",
                               
                //                RentDate = r.RentDate,
                //                ReturnDate = r.ReturnDate

                //             };
              
                return result.ToList();
            }
        }
    }
}
