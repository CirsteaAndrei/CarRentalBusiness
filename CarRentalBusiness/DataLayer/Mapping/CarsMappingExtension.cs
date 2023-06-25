using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public static class CarsMappingExtension
    {

        public static CarDto ToCarDto(this Car car)
        {
            if (car == null) return null;

            var result = new CarDto();
            result.Id = car.Id;
            result.Manifacturer_Model = car.Manifacturer +" "+car.Model;
            result.Interest = car.Interest;
            result.CategoryId = car.Category.Id;
            result.CategoryName = car.Category.Name;
            result.Contracts = car.Contracts.ToRentingContractDtos();

            return result;
        }

        public static List<CarDto> ToCarDtos(this List<Car> cars)
        {
            var result = cars.Select(e => e.ToCarDto()).ToList();
            return result;
        }
    }
}
