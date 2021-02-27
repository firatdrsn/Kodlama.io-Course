using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            if (_colorDal.GetAll(c => c.ColorName == color.ColorName).Count == 0)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.RecordAdded);
            }
            return new ErrorResult(Messages.SameColorAvailable);
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

        public IResult Update(Color color)
        {
            if (color != null && GetById(color.Id).Success)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
