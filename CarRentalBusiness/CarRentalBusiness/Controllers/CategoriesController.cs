using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalBusiness.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private CategoryService categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("/addCategory")]
        public IActionResult Add(CategoryAddDto payload)
        {
            var result = categoryService.Add(payload);
            if (result == null)
            {
                return BadRequest("Car cannot be added");
            }
            return Ok(result);
        }

        [HttpGet("/get-all-categories")]
        public ActionResult<List<Category>> GetAll()
        {
            var results = categoryService.GetAll();

            return Ok(results);
        }

        [HttpDelete("delete/{categoryId}")]
        public ActionResult<Car> Delete([FromRoute] int categoryId)
        {
            var result = categoryService.Delete(categoryId);

            if (result == null)
            {
                return BadRequest("Category could not be deleted");
            }

            return Ok(result);
        }
    }
}
