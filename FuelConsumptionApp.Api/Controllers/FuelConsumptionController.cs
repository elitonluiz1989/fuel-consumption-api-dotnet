using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FuelConsumptionApp.Api.Controllers
{
    [Route("api/fuel-consumption")]
    [ApiController]
    public class FuelConsumptionController : Controller
    {
        private readonly IFuelConsumptionService _service;

        public FuelConsumptionController(
            INotificationService notificationService,
            IUnitOfWork unitOfWork,
            IFuelConsumptionService service
        )
            : base(notificationService, unitOfWork)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _service.List();

            return Ok(cars);
        }

        [HttpPut("fuel")]
        public async Task<IActionResult> Fuel([FromBody] FuelConsumptionServiceDto dto)
        {
            var record = await _service.Fuel(dto);

            return ResponseWithCommit(record);
        }

        [HttpPut("run")]
        public async Task<IActionResult> Run([FromBody] FuelConsumptionServiceDto dto)
        {
            var record = await _service.Run(dto);

            return ResponseWithCommit(record);
        }
    }
}
