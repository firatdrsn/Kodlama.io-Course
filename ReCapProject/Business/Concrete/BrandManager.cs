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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(_brandDal.GetAll(b=>b.BrandName==brand.BrandName).Count==0)
            {
                _brandDal.Add(brand);
               return new SuccessResult(Messages.BrandAdded);

            }
            return new ErrorResult(Messages.SameBrandAvailable);
        }

        public IResult Delete(Brand brand)
        {
            Brand deletedBrand = _brandDal.GetById(b=>b.Id==brand.Id);
            if (deletedBrand!=null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            List<Brand> brandList = _brandDal.GetAll();
            if (brandList.Count>0)
            {
                return new SuccessDataResult<List<Brand>>(brandList);
            }
            return new ErrorDataResult<List<Brand>>(Messages.NoRecordsToList);
        }

        public IDataResult<Brand> GetByID(int Id)
        {
            Brand brand = _brandDal.GetById(b => b.Id == Id);
            if (brand!=null)
            {
                return new SuccessDataResult<Brand>(brand);
            }
            return new ErrorDataResult<Brand>(Messages.IdInvalid);
        }

        public IResult Update(Brand brand)
        {
            Brand updatedBrand = _brandDal.GetById(b=>b.Id==brand.Id);
            if (updatedBrand!=null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
