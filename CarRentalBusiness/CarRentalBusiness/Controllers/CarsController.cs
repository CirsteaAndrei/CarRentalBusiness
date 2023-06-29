using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalBusiness.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private CarService carService { get; set; }

        public CarsController(CarService carService)
        {
            this.carService = carService;
        }

        [HttpPost("/add")]
        public IActionResult Add(CarAddDto payload)
        {
            var result = carService.AddCar(payload);
            if(result == null)
            {
                return BadRequest("Car cannot be added");
            }
            return Ok(result);
        }

        [HttpGet("/get-all")]
        public ActionResult<List<Car>> GetAll()
        {
            var results = carService.GetAll();

            return Ok(results);
        }

        [HttpDelete("delete/{carId}")]
        public ActionResult<Car> Delete([FromRoute] int carId) {
            var result = carService.Delete(carId);

            if (result == false)
            {
                return BadRequest("Car could not be deleted");
            }

            return Ok(result);
        }

        [HttpPatch("edit-horsePower")]
        public ActionResult<bool> EditHp([FromBody] CarUpdateHPDto carUpdateDto)
        {
            var result = carService.EditHP(carUpdateDto);

            if (!result)
            {
                return BadRequest("Car HP could not be updated.");
            }

            return result;
        }

        [HttpPatch("edit-price")]
        public ActionResult<bool> EditPrice([FromBody] CarUpdatePrice carUpdatePrice)
        {
            var result = carService.EditPrice(carUpdatePrice);

            if (!result)
            {
                return BadRequest("Car price could not be updated.");
            }

            return result;
        }
    }
}
