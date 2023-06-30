using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class MechanicReportsRepository : RepositoryBase<MechanicReport>
    {
        private readonly AppDbContext dbContext;
        public MechanicReportsRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MechanicReport> GetReportsByCarId(int carId)
        {
            var results = dbContext.MechanicReports
                .Where(e => e.CarId == carId)

                .OrderBy(e => e.DateCreated)

                .ToList();

            return results;
        }
    }
}
