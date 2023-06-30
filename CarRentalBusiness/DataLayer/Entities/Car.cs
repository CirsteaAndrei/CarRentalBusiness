using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Car : BaseEntity
    {
        public string Manifacturer { get; set; }
        public string Model { get; set; }  
        public int Year { get; set; }
        public int Interest { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int HorsePower { get; set; }
        public int Doors { get; set; }
        public Transmission Transmission { get; set; }
        public FuelType FuelType { get; set; }
        public List<RentingContract> Contracts { get; set; }
        public List<MechanicReport> Reports { get; set; }
        public float Price { get; set; }
    }
}
