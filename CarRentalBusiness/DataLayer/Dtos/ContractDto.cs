using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string DateStart { get; set; }
        public int DaysDuration { get; set; }
        public float Profit { get; set; }
    }
}
