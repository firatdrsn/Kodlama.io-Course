using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.RecordAdded);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("ss");
            }
            Add(car);
            return null;
        }

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            if (car != null && GetById(car.Id).Success)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            if (_carDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Car>>(Messages.NoRecordsToList);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int Id)
        {
            if (_carDal.GetById(c => c.Id == Id) != null)
            {
                return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Car>(Messages.IdInvalid);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            if (_carDal.GetAllCarsDetails().Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoRecordsToList);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailById(int id)
        {
            if (_carDal.GetAllCarsDetails(c => c.Id == id) != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails(c => c.Id == id), Messages.RecordFound);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.IdInvalid);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int Id)
        {
            if (_carDal.GetAll(c => c.BrandId == Id).Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails(c => c.BrandId == Id), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoRecordsToList);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int Id)
        {
            if (_carDal.GetAll(c => c.ColorId == Id).Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails(c => c.ColorId == Id), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoRecordsToList);
        }
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
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
