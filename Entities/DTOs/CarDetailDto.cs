using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int BrandId { get; set; }//Cars & Brands
        public string BrandName { get; set; }//CarName  //Brands
        public int Id { get; set; } //Cars
        public int ColorId { get; set; } //Cars & Colors
        public decimal DailyPrice { get; set; } //Cars
        public string ColorName { get; set; } //Colors
    }
}
