using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class RentingContractsRepository : RepositoryBase<RentingContract>
    {
        private readonly AppDbContext dbContext;
        public RentingContractsRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public RentingContract GetByIdWithCar(int contractId)
        {
            var result = dbContext.RentingContracts
               .Select(e => new RentingContract
               {
                   Id = e.Id,
                   DateStart = e.DateStart,
                   DateEnd = e.DateEnd,
                   DaysDuration = e.DaysDuration,
                   Profit = e.Profit,
                   CarId = e.CarId,
                   Car = dbContext.Cars.Include(car => car.Id == e.CarId).FirstOrDefault(),

               })
               .FirstOrDefault(e => e.Id == contractId);

            return result;
        }

        public List<RentingContract> GetContractsByCarId(int carId)
        {
            var contracts = dbContext.RentingContracts
                .Where(e => e.CarId == carId)
                .OrderBy(contract => contract.DateStart)
                .ToList();

            return contracts;
        }
        public List<RentingContract> GetOverlappingContracts(int carId, DateTime dateStart, DateTime dateEnd)
        {
            var overlappingContracts = dbContext.RentingContracts
        .Where(contract =>
            contract.CarId == carId &&
            !(contract.DateEnd < dateStart || contract.DateStart > dateEnd))
        .OrderBy(contract => contract.DateStart)
        .ToList();

            return overlappingContracts;
        }
    }
}
