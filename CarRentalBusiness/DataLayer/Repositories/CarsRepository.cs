using DataLayer.Entities;
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

        public Car GetByIdWithContracts(int carId)
        {
            var result = dbContext.Cars
               .Select(e => new Car
               {
                   Manifacturer = e.Manifacturer,
                   Model = e.Model,
                   Id = e.Id,
                   Contracts = e.Contracts.ToList()
               })
               .FirstOrDefault(e => e.Id == carId);

            return result;
        }
    }
}
