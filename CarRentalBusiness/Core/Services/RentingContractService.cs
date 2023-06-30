using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
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

        public bool AddContractToCar(int carId, RentingContractAddDto contractDto)
        {
            var car = unitOfWork.Cars.GetById(carId);
            if (car == null)
                return false;

            DateTime dateStart = DateTime.Parse(contractDto.DateStart);
            DateTime dateEnd = DateTime.Parse(contractDto.DateEnd);
            int daysDuration = (dateEnd - dateStart).Days;

            var overlappingContracts = unitOfWork.RentingContracts.GetOverlappingContracts(carId, dateStart, dateEnd);

            if (overlappingContracts.Count > 0)
            {
                return false;
            }

            var contract = new RentingContract
            {
                DateStart = dateStart,
                DateEnd = dateEnd,
                DaysDuration = daysDuration,
                Profit = car.Price*contractDto.DaysDuration,
                CarId = carId,
                Car = car
            };

            car.Interest++;

            unitOfWork.RentingContracts.Insert(contract);
            unitOfWork.SaveChanges();

            return true;
        }
        public List<RentingContractDto> GetAll()
        {
            var results = unitOfWork.RentingContracts.GetAll().ToRentingContractDtos();

            return results;
        }

        public RentingContractDto GetById(int contractId)
        {
            var rentingContract = unitOfWork.RentingContracts.GetById(contractId);

            var result = rentingContract.ToRentingContractDto();

            return result;
        }

        public bool UpdateContract(int contractId, RentingContractAddDto contractDto)
        {
            var contract = unitOfWork.RentingContracts.GetById(contractId);
            if (contract == null)
                return false;

            var car = unitOfWork.Cars.GetById(contract.CarId);
            if (car == null)
                return false;

            contract.DateStart = DateTime.Parse(contractDto.DateStart);
            contract.DaysDuration = contractDto.DaysDuration;
            contract.Profit = car.Price * contract.DaysDuration;

            unitOfWork.RentingContracts.Update(contract);
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

        public List<RentingContractDto> GetContractsByCar(int carId)
        {
            var contracts = unitOfWork.RentingContracts.GetContractsByCarId(carId);
            var results = contracts.ToRentingContractDtos();
            return results;
        }

    }
}
