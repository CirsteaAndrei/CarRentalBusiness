using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CarAddDto
    {
        [Required]
        public string Manifacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public Transmission Transmission { get; set; }
        [Required]
        public FuelType FuelType { get; set; }
        public float Price { get; set; }
    }
}
