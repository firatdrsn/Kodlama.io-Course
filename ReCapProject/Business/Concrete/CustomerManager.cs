using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer service)
        {
            _customerDal.Add(service);
            return new SuccessResult();
        }

        public IResult Delete(Customer service)
        {
            _customerDal.Delete(service);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetByID(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetById(u => u.Id == Id));
        }

        public IResult Update(Customer service)
        {
            _customerDal.Update(service);
            return new SuccessResult();
        }
    }
}
