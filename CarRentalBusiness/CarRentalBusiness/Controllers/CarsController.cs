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

        [HttpPost("/addCar")]
        public IActionResult Add(CarAddDto payload)
        {
            var result = carService.AddCar(payload);
            if(result == null)
            {
                return BadRequest("Car cannot be added");
            }
            return Ok(result);
        }

        [HttpGet("/get-all-cars")]
        public ActionResult<List<Car>> GetAll()
        {
            var results = carService.GetAll();

            return Ok(results);
        }

        [HttpDelete("/delete/{carId}")]
        public ActionResult<Car> Delete([FromRoute] int carId) {
            var result = carService.Delete(carId);

            if (result == null)
            {
                return BadRequest("Car could not be deleted");
            }

            return Ok(result);
        }

        [HttpPatch("edit-car")]
        public ActionResult<bool> GetById([FromBody] CarUpdateDto carUpdateDto)
        {
            var result = carService.Edit(carUpdateDto);

            if (!result)
            {
                return BadRequest("Car could not be updated.");
            }

            return result;
        }
    }
}
