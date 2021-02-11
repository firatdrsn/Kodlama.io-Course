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
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (_colorDal.GetAll(c=>c.ColorName==color.ColorName).Count==0)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            return new ErrorResult(Messages.SameColorAvailable);
        }

        public IResult Delete(Color color)
        {
            Color deletedColor = _colorDal.GetById(c=>c.Id==color.Id);
            if (deletedColor!=null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<Color>> GetAll()
        {
            List<Color> colorList = _colorDal.GetAll();
            if (colorList.Count>0)
            {
                return new SuccessDataResult<List<Color>>(colorList);
            }
            return new ErrorDataResult<List<Color>>(Messages.NoRecordsToList);
        }

        public IDataResult<Color> GetByID(int Id)
        {
            Color color = _colorDal.GetById(c => c.Id == Id);
            if (color!=null)
            {
                return new SuccessDataResult<Color>(color);
            }
            return new ErrorDataResult<Color>(Messages.IdInvalid);
        }

        public IResult Update(Color color)
        {
            Color updatedColor = _colorDal.GetById(c=>c.Id==color.Id);
            if (updatedColor!=null)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
