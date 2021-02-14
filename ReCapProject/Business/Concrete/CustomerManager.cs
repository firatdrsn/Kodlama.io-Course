using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            if (_customerDal.GetAll(c => c.UserId == service.UserId).Count == 0)
            {
                _customerDal.Add(service);
                return new SuccessResult(Messages.RecordAdded);
            }
            return new ErrorResult(Messages.UserHasCompany);
        }

        public IResult Delete(Customer service)
        {
            if (service != null)
            {
                _customerDal.Delete(service);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (_customerDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Customer>>(Messages.NoRecordsToList);
        }

        public IDataResult<Customer> GetByID(int Id)
        {
            if (_customerDal.GetById(u => u.Id == Id) != null)
            {
                return new SuccessDataResult<Customer>(_customerDal.GetById(u => u.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Customer>(Messages.IdInvalid);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            if (_customerDal.GetCustomerDetails().Count>0)
            {
                return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(),Messages.RecordsListed);
            }
            return new ErrorDataResult<List<CustomerDetailDto>>(Messages.NoRecordsToList);
        }

        public IResult Update(Customer service)
        {
            if (service!=null)
            {
                _customerDal.Update(service);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
