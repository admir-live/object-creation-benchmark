namespace Corr2.Notification.PoC;

public static class Constants
{
    public static class Kafka
    {
        public const string BootstrapServers = "localhost:9092";
        public const string GroupId = "notification-consumer-group"; // We can use group per tenant or even per user if needed for more complex scenarios or performance reasons
        public const string Topic = "notification-topic"; // We can use topic per tenant or even per user if needed for more complex scenarios or performance reasons
    }

    public static class SignalR
    {
        public const string NotificationHub = "/hubs/notification";
        public const string ReceiveNotification = "ReceiveNotification";
    }
}
