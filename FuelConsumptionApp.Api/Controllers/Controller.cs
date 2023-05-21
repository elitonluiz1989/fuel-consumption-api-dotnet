using FuelConsumptionApp.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FuelConsumptionApp.Api.Controllers
{
    public class Controller : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IUnitOfWork _unitOfWork;

        public Controller(
            INotificationService notificationService,
            IUnitOfWork unitOfWork
        )
        {
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
        }

        protected IActionResult ResponseWithCommit()
        {
            return ResponseWithCommit(true);
        }

        protected IActionResult ResponseWithCommit<T>(T result)
        {
            if (_notificationService.HasNotifications())
                return BadRequest(_notificationService.GetNotifications());

            _unitOfWork.Commit();

             return Ok(result);
        }
    }
}
