using FuelConsumptionApp.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FuelConsumptionApp.Api.Controllers
{
    [Route("api/fuel-consumption")]
    [ApiController]
    public class FuelConsumptionController : Controller
    {
        public FuelConsumptionController(
            INotificationService notificationService,
            IUnitOfWork unitOfWork
        )
            : base(notificationService, unitOfWork)
        {            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It's working!");
        }
    }
}
