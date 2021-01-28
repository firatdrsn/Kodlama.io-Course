using GameMarketDemo.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameMarketDemo.Business
{
    public abstract class  BaseManager<ClassType> : IManagerService<ClassType>
    {
        public List<ClassType> List = new List<ClassType>();
        public virtual void Add(ClassType manager)
        {
            List.Add(manager);
        }
        public void Delete(ClassType manager)
        {
            List.Remove(manager);
        }

        public List<ClassType> GetList()
        {
            return List;
        }
        public abstract void GetListWrite();
        public abstract void Update(ClassType manager);
    }
}
