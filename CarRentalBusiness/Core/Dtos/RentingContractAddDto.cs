using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class RentingContractAddDto
    {
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public int DaysDuration { get; set; }
    }
}
