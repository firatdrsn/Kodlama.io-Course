using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICarService : IBaseService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int Id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int Id);
        IDataResult<List<CarDetailDto>> GetAllCarsDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailById(int id);
        IResult AddTransactionalTest(Car car);
    }
}
