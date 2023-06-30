using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CarsRepository : RepositoryBase<Car>
    {
        private readonly AppDbContext dbContext;
        public CarsRepository(AppDbContext dbContext) : base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public Car GetByIdWithContractsAndReports(int carId)
        {
            var result = dbContext.Cars
               .Select(e => new Car
               {
                   Manifacturer = e.Manifacturer,
                   Model = e.Model,
                   Id = e.Id,
                   Contracts = dbContext.RentingContracts.Include(contract =>
                    contract.CarId == carId)
                   .OrderBy(contract => contract.DateStart)
                   .ToList(),
                    Reports = dbContext.MechanicReports.Include(report =>
                    report.CarId == carId)
                   .OrderBy(report => report.DateCreated)
                   .ToList(),
               })
               .FirstOrDefault(e => e.Id == carId);

            return result;
        }
    }
}
