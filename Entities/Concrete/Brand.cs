using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity//Sen bir veri tabanı nesnesisin şeklinde işaretlendi
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
