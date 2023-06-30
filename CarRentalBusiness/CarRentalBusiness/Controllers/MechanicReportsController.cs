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
    [Route("api/mechanicReports")]
    public class MechanicReportsController : ControllerBase
    {
        private MechanicReportService reportService { get; set; }

        public MechanicReportsController(MechanicReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpPost("add")]
        public IActionResult Add(ReportAddDto payload)
        {
            var result = reportService.AddMechanicReport(payload);
            if (result == null)
            {
                return BadRequest("Car cannot be added");
            }
            return Ok(result);
        }

        [HttpGet("get-all")]
        public ActionResult<List<MechanicReportDto>> GetAll()
        {
            var results = reportService.GetAll();

            return Ok(results);
        }

        [HttpGet("get/{reportId}")]
        public ActionResult<MechanicReportDto> GetById([FromRoute] int reportId)
        {
            var result = reportService.GetById(reportId);

            if (result == null)
            {
                return BadRequest("Mechanic report not fount");
            }

            return Ok(result);
        }

        [HttpDelete("delete/{mechanicReportId}")]
        public ActionResult<Car> Delete([FromRoute] int mechanicReportId)
        {
            var result = reportService.Delete(mechanicReportId);

            if (result == false)
            {
                return BadRequest("Mechanic report could not be deleted");
            }

            return Ok(result);
        }

        [HttpGet("get-all-byCar/{carId}")]
        public ActionResult<List<MechanicReportDto>> GetAllByCar([FromRoute] int carId)
        {
            var result = reportService.GetReportsByCar(carId);

            if (result == null)
            {
                return BadRequest("Mechanic reports not fount");
            }

            return Ok(result);
        }
    }
}
