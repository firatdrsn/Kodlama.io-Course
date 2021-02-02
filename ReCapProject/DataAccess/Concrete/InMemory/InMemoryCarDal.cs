using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=150,Description="üstü açık bmw",ModelYear=2015 },
                new Car {Id=2,BrandId=1,ColorId=2,DailyPrice=180,Description="volvo jip",ModelYear=2016 },
                new Car {Id=3,BrandId=2,ColorId=4,DailyPrice=250,Description="lancher evo modeli",ModelYear=2018 },
                new Car {Id=4,BrandId=2,ColorId=6,DailyPrice=100,Description="fiorino",ModelYear=2010 },
                new Car {Id=5,BrandId=3,ColorId=4,DailyPrice=400,Description="lamborghini",ModelYear=2020 },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
