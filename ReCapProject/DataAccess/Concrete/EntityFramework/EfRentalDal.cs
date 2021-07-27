using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentacarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join ctr in context.Customers
                             on r.CustomerId equals ctr.Id
                             join u in context.Users
                             on ctr.UserId equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new RentalDetailDto { RentalId = r.Id, CarId = c.Id, CarName = c.CarName, BrandName = b.BrandName, UserName = u.UserName, FirstName = u.FirstName, LastName = u.LastName, CompanyName = ctr.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
