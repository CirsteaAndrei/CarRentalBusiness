using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
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
        public ActionResult<bool> AddToCar([FromRoute] int carId, [FromBody] Core.Dtos.RentingContractAddDto contractDto)
        {
            var result = contractService.AddContractToCar(carId, contractDto);
            if (!result)
            {
                return BadRequest("Failed to add contract to car.");
            }

            return Ok("Contract added successfully.");
        }

        [HttpGet("get-all")]
        public ActionResult<List<DataLayer.Dtos.RentingContractDto>> GetAll()
        {
            var results = contractService.GetAll();

            return Ok(results);
        }

        [HttpGet("get/{contractId}")]
        public ActionResult<Core.Dtos.RentingContractAddDto> GetById([FromRoute] int contractId)
        {
            var result = contractService.GetById(contractId);

            if (result == null)
            {
                return BadRequest("Mechanic report not fount");
            }

            return Ok(result);
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

        [HttpPatch("update/{contractId}")]
        public ActionResult<bool> UpdateContract([FromRoute] int contractId, [FromBody] Core.Dtos.RentingContractAddDto contractDto)
        {
            var result = contractService.UpdateContract(contractId, contractDto);
            if (!result)
            {
                return BadRequest("Failed to update the contract.");
            }

            return Ok("Contract updated successfully.");
        }
    }
}
