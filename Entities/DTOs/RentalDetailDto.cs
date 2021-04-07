using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDto:IDto
    {
        public string BrandName { get; set; }
        public string CustomerInfo { get; set; }
        public string CompanyName { get; set; }  
        public DateTime? ReturnDate { get; set; }//Araba teslim edilmemişme teslim tarihi null olur
        public DateTime RentDate { get; set; }

    }
}
