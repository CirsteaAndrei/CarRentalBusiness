using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public static class RentingContractsMappingExtension
    {
        public static List<ContractDto> ToRentingContractDtos(this List<RentingContract> rentingContracts)
        {
            if (rentingContracts == null)
            {
                return null;
            }

            var results = rentingContracts.Select(e => e.ToRentingContractDto()).ToList();

            return results;
        }

        public static ContractDto ToRentingContractDto(this RentingContract rentingContract)
        {
            if (rentingContract == null) return null;

            var result = new ContractDto();
            result.Profit = rentingContract.Profit;
            result.DateStart = rentingContract.DateStart.ToString();
            result.DaysDuration = rentingContract.DaysDuration;

            return result;
        }
    }
}
