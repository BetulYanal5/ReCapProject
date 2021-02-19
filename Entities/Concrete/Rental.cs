using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Rental : IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? ReturnDate { get; set; }//Araba teslim edilmemişme teslim tarihi null olur
        public DateTime RentDate { get; set; }
    }
}
