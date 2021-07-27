using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer service)
        {
            if (_customerDal.GetAll(c => c.UserId == service.UserId).Count == 0)
            {
                _customerDal.Add(service);
                return new SuccessResult(Messages.RecordAdded);
            }
            return new ErrorResult(Messages.UserHasCompany);
        }
        [SecuredOperation("customer.delete,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer service)
        {
            if (service != null && GetById(service.Id).Success)
            {
                _customerDal.Delete(service);
                return new SuccessResult(Messages.RecordDeleted);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
        //[SecuredOperation("customers.list,admin")]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            if (_customerDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<Customer>>(Messages.NoRecordsToList);
        }
        [SecuredOperation("customers.list,admin")]
        [CacheAspect]
        public IDataResult<Customer> GetById(int Id)
        {
            if (_customerDal.GetById(u => u.Id == Id) != null)
            {
                return new SuccessDataResult<Customer>(_customerDal.GetById(u => u.Id == Id), Messages.RecordFound);
            }
            return new ErrorDataResult<Customer>(Messages.IdInvalid);
        }
        [SecuredOperation("customers.list,admin")]
        [CacheAspect]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            if (_customerDal.GetCustomerDetails().Count > 0)
            {
                return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.RecordsListed);
            }
            return new ErrorDataResult<List<CustomerDetailDto>>(Messages.NoRecordsToList);
        }
        [SecuredOperation("customer.update,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer service)
        {
            if (service != null && GetById(service.Id).Success)
            {
                _customerDal.Update(service);
                return new SuccessResult(Messages.RecordUpdated);
            }
            return new ErrorResult(Messages.IdInvalid);
        }
    }
}
