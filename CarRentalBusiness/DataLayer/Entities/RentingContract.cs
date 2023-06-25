using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class RentingContract : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public int DaysDuration { get; set; }
        public float Profit { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
