using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelConsumption.Api.Controllers
{
    [Route("api/fuel-consumption")]
    [ApiController]
    public class FuelConsumptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It's working!");
        }
    }
}
