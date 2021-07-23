using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName), CheckIfNull(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.RecordAdded);
        }
        [SecuredOperation("brand.delete,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            if (!GetById(brand.Id).Success && brand == null)
            {
                return new ErrorResult(Messages.IdInvalid);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.RecordDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            if (_brandDal.GetAll().Count == 0)
            {
                return new ErrorDataResult<List<Brand>>(Messages.NoRecordsToList);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.RecordsListed);
        }
        [CacheAspect]
        public IDataResult<Brand> GetById(int Id)
        {
            if (!_brandDal.GetAll(b => b.Id == Id).Any())
            {
                return new ErrorDataResult<Brand>(Messages.IdInvalid);
            }
            return new SuccessDataResult<Brand>(_brandDal.GetById(b => b.Id == Id), Messages.RecordFound);
        }
        [SecuredOperation("brand.update,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName), CheckIfNull(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.RecordUpdated);
        }

        private IResult CheckIfBrandNameExists(string brandName)
        {
            if (_brandDal.GetAll(b => b.BrandName == brandName).Any())
            {
                return new ErrorResult(Messages.SameBrandAvailable);
            }
            return new SuccessResult();
        }
        private IResult CheckIfNull(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.RecordNull);
            }
            return new SuccessResult();
        }
    }
}
