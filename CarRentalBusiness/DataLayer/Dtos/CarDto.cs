using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Manifacturer_Model { get; set; }
        public int Interest { get; set; }
        public int CategoryId { get; set; }
    }
}
