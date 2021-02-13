using Business.Abstract;
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
            _userDal.Add(service);
            return new SuccessResult();
        }

        public IResult Delete(User service)
        {
            _userDal.Delete(service);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll()," listelendi");
        }

        public IDataResult<User> GetByID(int Id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(u => u.Id == Id));
        }

        public IResult Update(User service)
        {
            _userDal.Update(service);
            return new SuccessResult();
        }
    }
}
