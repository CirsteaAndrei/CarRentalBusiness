using Core.Dtos;
using DataLayer.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Dtos;
using DataLayer.Mapping;

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

            var car = unitOfWork.Cars.GetById(payload.CarId);
            if (car == null) return null;

            var newReport = new MechanicReport
            {
                CarId = payload.CarId,
                IsWorking = payload.IsWorking,
                ConditionScore = payload.ConditionScore,
                DamagedParts = payload.DamagedParts,
                EstRepairingCost = payload.EstRepairingCost,
                DateCreated = DateTime.Parse(payload.DateCreated),
            };

            unitOfWork.MechanicReports.Insert(newReport);
            unitOfWork.SaveChanges();
            return payload;
        }
        public List<MechanicReportDto> GetAll()
        {
            var results = unitOfWork.MechanicReports.GetAll().ToMechanicReportDtos();

            return results;
        }

        public MechanicReportDto GetById(int reportId)
        {
            var mechanicReport = unitOfWork.MechanicReports.GetById(reportId);

            var result = mechanicReport.ToMechanicReportDto();

            return result;
        }

        public bool Delete(int MechanicReportId)
        {
            var mechanicReport = unitOfWork.MechanicReports.GetById(MechanicReportId);
            if (mechanicReport == null) return false;

            unitOfWork.MechanicReports.Remove(mechanicReport);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
