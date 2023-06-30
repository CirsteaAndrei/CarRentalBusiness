using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public static class MechanicReportsMappingExtensions
    {
        public static MechanicReportDto ToMechanicReportDto(this MechanicReport report)
        {
            if (report == null) return null;

            var result = new MechanicReportDto();
            result.Id = report.Id;
            result.IsWorking= report.IsWorking;
            result.ConditionScore = report.ConditionScore;
            result.DamagedParts = report.DamagedParts;
            result.EstRepairingCost = report.EstRepairingCost;
            result.DateCreated = report.DateCreated.ToString();
            result.CarId = report.CarId;

            return result;
        }

        public static List<MechanicReportDto> ToMechanicReportDtos(this List<MechanicReport> reports)
        {
            var result = reports.Select(e => e.ToMechanicReportDto()).ToList();
            return result;
        }
    }
}
