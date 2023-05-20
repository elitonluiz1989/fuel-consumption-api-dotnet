namespace FuelConsumptionApp.Contracts
{
    public interface INotificationService
    {
        void AddNotification(string notification);
        void AddNotifications(List<string> notifications);
        bool HasNotifications();
        List<string> GetNotifications();
    }
}
