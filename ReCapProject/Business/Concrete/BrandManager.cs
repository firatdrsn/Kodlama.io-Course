using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);

            if (_brandDal.GetAll(b => b.BrandName == brand.BrandName).Count == 0)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.RecordAdded);

            }

            return new ErrorResult(Messages.SameBrandAvailable);
        }

        public IResult Delete(Brand brand)
        {
            if (brand != null && GetById(brand.Id).Success)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (_brandDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Brand>>(Messages.NoRecordsToList);
        }

        public IDataResult<Brand> GetById(int Id)
        {
            if (_brandDal.GetAll(b => b.Id == Id).Count>0)
            {
                return new SuccessDataResult<Brand>(_brandDal.GetById(b => b.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Brand>(Messages.IdInvalid);
        }

        public IResult Update(Brand brand)
        {
            if (brand != null && GetById(brand.Id).Success)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
