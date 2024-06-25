using Confluent.Kafka;

namespace corr2_notification;

public class KafkaProducerService(IProducer<Null, string> producer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = new Message<Null, string> { Value = "Hello, Stanić! " + Guid.NewGuid().ToString("N") };
            await producer.ProduceAsync("notification-topic", message, stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
