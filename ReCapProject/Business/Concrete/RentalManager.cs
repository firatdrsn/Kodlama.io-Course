using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental service)
        {
            if (GetUndeliveredCarsDetails().Data.Where(c => c.CarId == service.CarId).Count() == 0)
            {
                _rentalDal.Add(service);
                return new SuccessResult(Messages.RecordAdded);
            }
            return new ErrorResult(Messages.CarNotDelivered);
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (_rentalDal.GetRentalDetails().Count > 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
            }
            return new ErrorDataResult<List<RentalDetailDto>>(Messages.NoRecordsToList);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental service)
        {
            if (service != null && service.ReturnDate >= service.RentDate && GetById(service.Id).Success)
            {
                _rentalDal.Update(service);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdOrDateInvalid);
        }

        public IResult Delete(Rental service)
        {
            if (service != null && GetById(service.Id).Success)
            {
                _rentalDal.Delete(service);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (_rentalDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Rental>>(Messages.NoRecordsToList);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            if (_rentalDal.GetById(r => r.Id == Id) != null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.GetById(u => u.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Rental>(Messages.IdInvalid);
        }

        public IDataResult<List<RentalDetailDto>> GetUndeliveredCarsDetails()
        {
            if (_rentalDal.GetRentalDetails(c => c.ReturnDate == null).Count > 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.ReturnDate == null));
            }
            return new ErrorDataResult<List<RentalDetailDto>>(Messages.NoRecordsToList);
        }
    }
}
