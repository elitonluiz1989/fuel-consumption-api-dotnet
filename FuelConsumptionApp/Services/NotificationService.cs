using FuelConsumptionApp.Contracts;

namespace FuelConsumptionApp.Services
{
    public class NotificationService : INotificationService
    {
        private readonly List<string> _notifications = new ();

        public void AddNotification(string notification)
        {
            _notifications.Add(notification);
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
