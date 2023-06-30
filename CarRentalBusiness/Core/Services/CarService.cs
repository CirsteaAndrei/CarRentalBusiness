using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class CarService
    {
        private readonly UnitOfWork unitOfWork;
        public CarService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public CarAddDto AddCar(CarAddDto payload)
        {
            if (payload == null) return null;

            var category = unitOfWork.Categories.GetById(payload.CategoryId);
            if (category == null) return null;

            var newCar = new Car
            {
                Manifacturer = payload.Manifacturer,
                Model = payload.Model,
                Year = payload.Year,
                CategoryId = payload.CategoryId,
                Category = category,
                HorsePower = payload.HorsePower,
                Doors = payload.Doors,
                Transmission = payload.Transmission,
                FuelType = payload.FuelType,
                Price = payload.Price + category.Warranty
            };

            //if (category.Cars.IsNullOrEmpty())
            //{
            //    category.Cars = new List<Car> { newCar };
            //}
            //else
            //    category.Cars.Add(newCar);

            unitOfWork.Cars.Insert(newCar);
            unitOfWork.SaveChanges();

            return payload;
        }
        public List<CarDto> GetAll()
        {
            var results = unitOfWork.Cars.GetAll().ToCarDtos();

            return results;
        }

        public CarDto GetById(int carId)
        {
            var car = unitOfWork.Cars.GetById(carId);

            var result = car.ToCarDto();

            return result;
        }

        public bool Delete(int carId)
        {
            var car = unitOfWork.Cars.GetById(carId);
            if (car == null) return false;

            //delete cascade
            var associatedReports = unitOfWork.MechanicReports.GetReportsByCarId(carId);
            foreach (var report in associatedReports)
            {
                unitOfWork.MechanicReports.Remove(report);
            }

            unitOfWork.Cars.Remove(car);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool EditHP(CarUpdateHPDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Cars.GetById(payload.Id);
            if (result == null) return false;

            if (payload.HorsePower > 0)
            {
                result.HorsePower = payload.HorsePower;
            }
            unitOfWork.SaveChanges();
            return true;
        }

        public bool EditPrice(CarUpdatePrice payload)
        {
            var car = unitOfWork.Cars.GetById(payload.Id);
            if (car == null) return false;
            if(payload.Price == 0) return false;
            car.Price = payload.Price;
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
