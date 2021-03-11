using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int UserId { get; set; }//Customers, Users
        public string CompanyName { get; set; }//Customers
        public int CustomerId { get; set; }//Customers, Rentals
        public string FirstName { get; set; }//Users
        public string LastName { get; set; }//Users
        public string Email { get; set; }//Users
        public DateTime ReturnDate { get; set; }//Rentals
    }
}
