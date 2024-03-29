﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentacarContext>, ICarDal
    {

        public List<CarDetailDto> GetAllCarsDetails(Expression<Func<Car, bool>> filter)
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from c in filter == null ? context.Cars.ToList() : context.Cars.Where(filter).ToList()
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 CarName = c.CarName,
                                 DailyPrice = Convert.ToInt32(c.DailyPrice),
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
