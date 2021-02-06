using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>=2&&car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("Araç bilgisi 2 karakterden kısa veya günlük ücreti 0 veya altında");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByID(int Id)
        {
            return _carDal.GetById(c=>c.Id==Id);
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(c=>c.BrandId==Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(c=>c.ColorId==Id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
