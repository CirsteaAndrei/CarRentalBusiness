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
        public static MechanicReportDto ToReportDto(this MechanicReport report)
        {
            if (report == null) return null;

            var result = new MechanicReportDto();
            result.Id = report.Id;
            result.IsWorking= report.IsWorking;
            result.ConditionScore = report.ConditionScore;
            result.DamagedParts = report.DamagedParts;
            result.EstRepairingCost = report.EstRepairingCost;
            result.DateCreated = report.DateCreated.ToString();

            return result;
        }

        public static List<MechanicReportDto> ToReportDtos(this List<MechanicReport> reports)
        {
            var result = reports.Select(e => e.ToReportDto()).ToList();
            return result;
        }
    }
}
