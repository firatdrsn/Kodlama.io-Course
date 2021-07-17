using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User service)
        {
            if (_userDal.GetAll(u => u.UserName == service.UserName).Count == 0)
            {
                _userDal.Add(service);
                return new SuccessResult(Messages.RecordAdded);
            }
            return new ErrorResult(Messages.UserAlreadyExits);
        }

        public IResult Delete(User service)
        {
            if (service != null && GetById(service.Id).Success)
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

        public IDataResult<User> GetById(int Id)
        {
            if (_userDal.GetById(u => u.Id == Id) != null)
            {
                return new SuccessDataResult<User>(_userDal.GetById(u => u.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<User>(Messages.IdInvalid);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            if (!_userDal.GetAll(u => u.UserName == userName).Any())
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(_userDal.GetById(u => u.UserName == userName), Messages.RecordFound);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            if (user == null)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.IdInvalid);
            }
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User service)
        {
            if (service != null && GetById(service.Id).Success)
            {
                _userDal.Update(service);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
