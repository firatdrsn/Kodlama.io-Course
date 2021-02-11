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
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                //throw new Exception("Araç Adı 2 karakterden kısa veya günlük ücreti 0 veya altında");
                return new ErrorResult(Messages.CarNameOrDailPriceInvalid);
            }

        }

        public IResult Delete(Car car)
        {
            Car deletedCar = _carDal.GetById(c => c.Id == car.Id);
            if (deletedCar!=null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
            {
                return new ErrorResult(Messages.IdInvalid);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            List<Car> carListResult = _carDal.GetAll();
            if (carListResult.Count > 0)
            {
                return new SuccessDataResult<List<Car>>(carListResult);
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
            }
        }

        public IDataResult<Car> GetByID(int Id)
        {
            Car carResult = _carDal.GetById(c => c.Id == Id);
            if (carResult != null)
            {
                return new SuccessDataResult<Car>(carResult);
            }
            else
            {
                return new ErrorDataResult<Car>(Messages.IdInvalid);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            List<CarDetailDto> carDtoResult = _carDal.GetCarDetails();
            if (carDtoResult.Count>0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDtoResult);
            }
            else
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NoRecordsToList);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            List<Car> carListResult = _carDal.GetAll(c=>c.BrandId==Id);
            if (carListResult.Count>0)
            {
                return new SuccessDataResult<List<Car>>(carListResult);
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            List<Car> carListResult = _carDal.GetAll(c=>c.ColorId==Id);
            if(carListResult.Count>0)
            {
                return new SuccessDataResult<List<Car>>(carListResult);
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
            }
        }

        public IResult Update(Car car)
        {
            Car carUpdated = _carDal.GetById(c=>c.Id==car.Id);
            if(carUpdated!=null)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.IdInvalid);
            }
        }
    }
}
