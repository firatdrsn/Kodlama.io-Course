using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Abstract 
{
    public interface IManagerService<T>
    {
        void Add(T manager);
        void Update(T manager);
        void Delete(T manager);
        void GetListWrite();
        List<T> GetList();
    }
}
