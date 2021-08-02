using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        //[SecuredOperation("carimage.add,admin")]
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitOfCorrect(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.RecordAdded);
        }
        [SecuredOperation("carimage.delete,admin")]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.RecordDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.RecordsListed);
        }

        public IDataResult<List<CarImage>> GetAllImageByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageOfNull(id).Data, Messages.RecordsListed);
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(c => c.Id == Id), Messages.RecordFound);
        }
        [SecuredOperation("carimage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageOfNull(carImage.CarId));

            if (result != null)
            {
                return new ErrorResult(Messages.IdInvalid);
            }

            carImage.ImagePath = FileHelper.Update(_carImageDal.GetById(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.RecordUpdated);
        }
        private IResult CheckIfCarImageLimitOfCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitError);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageOfNull(int carId)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>() {
                        new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now }
                    };
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
    }
}
