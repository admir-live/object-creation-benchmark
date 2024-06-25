using Confluent.Kafka;
using corr2_notification.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace corr2_notification;

public class KafkaConsumerService(IConsumer<Null, string> consumer, IHubContext<NotificationHub> hubContext) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        consumer.Subscribe("notification-topic");

        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = consumer.Consume(stoppingToken);
            await hubContext.Clients.All.SendAsync("ReceiveNotification", consumeResult.Message.Value, stoppingToken);
        }

        consumer.Close();
    }
}
