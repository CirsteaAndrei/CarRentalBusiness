using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RentingContractService
    {
        private readonly UnitOfWork unitOfWork;

        public RentingContractService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AddContractToCar(int carId, ContractDto contractDto)
        {
            var car = unitOfWork.Cars.GetById(carId);
            if (car == null)
                return false;

            var contract = new RentingContract
            {
                DateStart = DateTime.Parse(contractDto.DateStart),
                DaysDuration = contractDto.DaysDuration,
                Profit = car.Price*contractDto.DaysDuration,
                CarId = carId,
                Car = car
            };

            unitOfWork.RentingContracts.Insert(contract);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool Delete(int rentingContractId)
        {
            var rentingContract = unitOfWork.RentingContracts.GetById(rentingContractId);
            if (rentingContract == null) return false;

            unitOfWork.RentingContracts.Remove(rentingContract);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
