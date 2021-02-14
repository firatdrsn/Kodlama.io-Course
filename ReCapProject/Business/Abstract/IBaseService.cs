using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : class, IEntity, new()
    {
        IResult Add(T service);
        IResult Update(T service);
        IResult Delete(T service);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetByID(int Id);
    }
}
