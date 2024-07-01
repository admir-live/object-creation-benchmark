using Confluent.Kafka;
using Corr2.Notification.PoC.Messaging.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Corr2.Notification.PoC.Messaging.Kafka.Consumers;

public class KafkaConsumerService(IConsumer<Null, string> consumer, IHubContext<NotificationHub> hubContext) : BackgroundService, IKafkaService
{
    public async Task StreamAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(2000, stoppingToken);

        consumer.Subscribe(Constants.Kafka.Topic);

        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = consumer.Consume(stoppingToken);
            await hubContext.Clients.All.SendAsync("ReceiveNotification", consumeResult.Message.Value, stoppingToken);
        }

        consumer.Close();
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await StreamAsync(stoppingToken);
    }
}
