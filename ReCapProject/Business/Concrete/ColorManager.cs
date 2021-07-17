using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExists(color.ColorName), CheckIfNull(color));
            if (result != null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.RecordAdded);
        }

        public IResult Delete(Color color)
        {
            if (color != null && GetById(color.Id).Success)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
        public IDataResult<List<Color>> GetAll()
        {
            if (_colorDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Color>>(Messages.NoRecordsToList);
        }
        public IDataResult<Color> GetById(int Id)
        {
            if (_colorDal.GetAll(c => c.Id == Id).Count > 0)
            {
                return new SuccessDataResult<Color>(_colorDal.GetById(c => c.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Color>(Messages.IdInvalid);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExists(color.ColorName), CheckIfNull(color));
            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.RecordUpdated);
        }
        private IResult CheckIfColorNameExists(string colorName)
        {
            if (_colorDal.GetAll(b => b.ColorName == colorName).Any())
            {
                return new ErrorResult(Messages.SameColorAvailable);
            }
            return new SuccessResult();
        }
        private IResult CheckIfNull(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.RecordNull);
            }
            return new SuccessResult();
        }
        
    }
}
