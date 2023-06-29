using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalBusiness.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class RentingContractsController : ControllerBase
    {
        private readonly RentingContractService contractService;

        public RentingContractsController(RentingContractService contractService)
        {
            this.contractService = contractService;
        }

        [HttpPost("add-to-car/{carId}")]
        public IActionResult AddToCar([FromRoute] int carId, [FromBody] ContractDto contractDto)
        {
            var result = contractService.AddContractToCar(carId, contractDto);
            if (!result)
            {
                return BadRequest("Failed to add contract to car.");
            }

            return Ok("Contract added successfully.");
        }

        [HttpDelete("delete/{rentingContractId}")]
        public ActionResult<Car> Delete([FromRoute] int rentingContractId)
        {
            var result = contractService.Delete(rentingContractId);

            if (result == false)
            {
                return BadRequest("Contract could not be deleted");
            }

            return Ok(result);
        }
    }
}
