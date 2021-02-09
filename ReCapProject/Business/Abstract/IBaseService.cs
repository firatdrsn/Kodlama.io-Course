using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseService<T>where T:class,IEntity,new()
    {
        void Add(T service);
        void Update(T service);
        void Delete(T service);
        List<T> GetAll();
        T GetByID(int Id);
    }
}
