using Confluent.Kafka;
using Corr2.Notification.PoC.Entities;
using Corr2.Notification.PoC.Infrastructure;
using Corr2.Notification.PoC.NotificationRuleEngine;
using Microsoft.EntityFrameworkCore;

namespace Corr2.Notification.PoC.Messaging.Kafka.Producers;

public class KafkaProducerService(IProducer<Null, string> producer, NotificationContext context) : BackgroundService, IKafkaService
{
    public async Task StreamAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(2000, stoppingToken);
        while (!stoppingToken.IsCancellationRequested)
        {
            var users = await context.Users
                .AsNoTracking()
                .Include(u => u.NotificationTemplates)
                .ThenInclude(t => t.Criteria)
                .ToArrayAsync(stoppingToken);

            Result sampleResult = new()
            {
                Customer = "VIP",
                SampleForm = "Liquid",
                SampleType = "Blood",
                Test = "positive",
                QntResult = 80, // Satisfies criteria for quantity > 70
                QltResult = 0.95m, // Satisfies criteria for quality > 0.9
                IsSuccess = true
            };

            foreach (var user in users)
            {
                foreach (var message in
                         from template in user.NotificationTemplates
                         from rule in template.Criteria
                             .Select(criteria => new DynamicRule(criteria.Expression, criteria.MessageTemplate))
                             .Where(rule => rule.IsSatisfiedBy(sampleResult))
                         select $"{rule.GetMessage(sampleResult)} for {user.Username} @ {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}"
                         into messageContent
                         select new Message<Null, string> { Value = messageContent })
                {
                    await producer.ProduceAsync(Constants.Kafka.Topic, message, stoppingToken);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await StreamAsync(stoppingToken);
    }
}
