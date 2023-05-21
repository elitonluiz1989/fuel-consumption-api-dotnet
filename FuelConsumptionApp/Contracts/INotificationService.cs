namespace FuelConsumptionApp.Contracts
{
    public interface INotificationService
    {
        void AddNotification(string notification);
        bool HasNotifications();
        List<string> GetNotifications();
    }
}
