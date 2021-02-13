using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental service)
        {
            _rentalDal.Add(service);
            return new SuccessResult();
        }

        public IResult Delete(Rental service)
        {
            _rentalDal.Delete(service);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByID(int Id)
        {
           return new SuccessDataResult<Rental>(_rentalDal.GetById(u => u.Id == Id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            List<RentalDetailDto> rentalDtoResult = _rentalDal.GetRentalDetails();
            if (rentalDtoResult.Count > 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDtoResult);
            }
            return new ErrorDataResult<List<RentalDetailDto>>(Messages.NoRecordsToList);
        }

        public IResult Update(Rental service)
        {
            _rentalDal.Update(service);
            return new SuccessResult();
        }
    }
}
