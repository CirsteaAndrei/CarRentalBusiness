using Core.Dtos;
using DataLayer.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MechanicReportService
    {
        private readonly UnitOfWork unitOfWork;
        public MechanicReportService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ReportAddDto AddMechanicReport(ReportAddDto payload)
        {
            if (payload == null) return null;
            if (unitOfWork.Cars.GetById(payload.CarId) == null) return null;

            var newCar = new MechanicReport
            {
                CarId = payload.CarId,
                IsWorking = payload.IsWorking,
                ConditionScore = payload.ConditionScore,
                DamagedParts = payload.DamagedParts,
                EstRepairingCost = payload.EstRepairingCost,
                DateCreated = DateTime.Parse(payload.DateCreated),
            };
            return payload;
        }

    }
}
