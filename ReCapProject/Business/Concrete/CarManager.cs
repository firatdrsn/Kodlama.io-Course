using Business.Abstract;
using Business.Constants;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.RecordAdded);
            }
            //throw new Exception("Araç Adı 2 karakterden kısa veya günlük ücreti 0 veya altında");
            return new ErrorResult(Messages.CarNameOrDailPriceInvalid);
        }

        public IResult Delete(Car car)
        {
            if (car != null && GetById(car.Id).Success)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (_carDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
        }

        public IDataResult<Car> GetById(int Id)
        {
            if (_carDal.GetById(c => c.Id == Id) != null)
            {
                return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Car>(Messages.IdInvalid);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (_carDal.GetCarDetails().Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoRecordsToList);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            if (_carDal.GetAll(c => c.BrandId == Id).Count > 0)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == Id), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            if (_carDal.GetAll(c => c.ColorId == Id).Count > 0)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
        }
        public IResult Update(Car car)
        {
            if (car != null && GetById(car.Id).Success)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
