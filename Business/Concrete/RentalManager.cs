using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (entity.RentDate < DateTime.Now || entity.ReturnDate < DateTime.Now)//Girilen kiralama veya teslim tarihi geçmiş tarih olmamalı
            {
                Console.WriteLine(Messages.RentalTimeError);
                return new ErrorResult(Messages.RentalTimeError);
            }
            if ((_rentalDal.Get(c => c.CarId == entity.CarId)) == null)//Kiralanan arabalar listesinde yoksa direkt kiralayabiliriz
            {
                _rentalDal.Add(entity);
                Console.WriteLine(Messages.Added);
                return new SuccessResult(Messages.Added);
            }
            else //Araba daha önce kiralanmışsa
            {
                foreach (var rentalList in _rentalDal.GetAll())
                {
                    if (rentalList.CarId == entity.CarId)//Kiralanan arabalar içerisinden kiralamak istediğimiz aracı arıyoruz
                    {
                        if (entity.RentDate > rentalList.ReturnDate)//Kiralamak istediğimiz aracın kiralama tarihi o aracın teslim tarihinden sonraysa işlem onaylanır
                        {
                            _rentalDal.Add(entity);
                            Console.WriteLine(Messages.Added);
                            return new SuccessResult(Messages.Added);
                        }
                    }
                }
                //Eğer araç geri verilmediyse o aracı kiralayamayız       
                Console.WriteLine(Messages.RentalError);
                return new ErrorResult(Messages.RentalError);
            }
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(Messages.Listed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == Id), Messages.Listed);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
