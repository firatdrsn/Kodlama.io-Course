using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentacarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
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
                             select new RentalDetailDto { RentalId=r.Id,CarName=c.CarName,UserName=u.UserName,FirstName=u.FirstName,LastName=u.LastName,CompanyName=ctr.CompanyName,RentDate=r.RentDate.ToString(),ReturnDate= r.ReturnDate==null ? "" : r.ReturnDate.Value.ToString() };
                return result.ToList();
            }
        }
    }
}
