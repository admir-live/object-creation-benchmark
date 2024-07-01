namespace Corr2.Notification.PoC.Messaging.Kafka;

public interface IKafkaService
{
    Task StreamAsync(CancellationToken stoppingToken);
}
