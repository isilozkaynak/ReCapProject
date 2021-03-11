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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDBContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDBContext context=new ReCapDBContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                               on c.UserId equals u.UserId
                             join r in context.Rentals
                               on c.CustomerId equals r.CustomerId
                             select new CustomerDetailDto
                             {
                                 UserId = u.UserId,
                                 CompanyName = c.CompanyName,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
