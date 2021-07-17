using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService : IBaseService<Customer>
    {
       IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
