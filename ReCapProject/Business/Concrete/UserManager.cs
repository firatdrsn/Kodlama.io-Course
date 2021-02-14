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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User service)
        {
            if (_userDal.GetAll(u => u.UserName == service.UserName).Count == 0)
            {
                _userDal.Add(service);
                return new SuccessResult(Messages.RecordAdded);
            }
            return new ErrorResult(Messages.SameUsernameAvailable);
        }

        public IResult Delete(User service)
        {
            if (service!=null)
            {
                _userDal.Delete(service);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (_userDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<User>>(Messages.NoRecordsToList);
        }

        public IDataResult<User> GetByID(int Id)
        {
            if (_userDal.GetById(u => u.Id == Id) != null)
            {
                return new SuccessDataResult<User>(_userDal.GetById(u => u.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<User>(Messages.IdInvalid);
        }

        public IResult Update(User service)
        {
            if (service!=null)
            {
                _userDal.Update(service);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
