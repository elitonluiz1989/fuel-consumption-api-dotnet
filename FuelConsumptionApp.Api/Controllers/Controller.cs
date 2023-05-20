using FuelConsumptionApp.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FuelConsumptionApp.Api.Controllers
{
    public class Controller : ControllerBase
    {
        private INotificationService _notificationService;
        private IUnitOfWork _unitOfWork;

        public Controller(
            INotificationService notificationService,
            IUnitOfWork unitOfWork
        )
        {
            _notificationService = notificationService;
            _unitOfWork = unitOfWork;
        }

        protected bool HasNotifications()
        {
            return _notificationService.HasNotifications();
        }
    }
}
