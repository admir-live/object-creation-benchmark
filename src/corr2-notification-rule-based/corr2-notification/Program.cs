using Confluent.Kafka;
using Corr2.Notification.PoC;
using Corr2.Notification.PoC.Infrastructure;
using Corr2.Notification.PoC.Messaging.Kafka.Consumers;
using Corr2.Notification.PoC.Messaging.Kafka.Producers;
using Corr2.Notification.PoC.Messaging.SignalR.Hubs;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddSignalR();
builder.Services.AddControllers();

builder.Services.AddDbContext<NotificationContext>(ServiceLifetime.Singleton);

builder.Services.AddSingleton<IProducer<Null, string>>(provider =>
{
    var config = new ProducerConfig { BootstrapServers = Constants.Kafka.BootstrapServers };
    return new ProducerBuilder<Null, string>(config).Build();
});

builder.Services.AddSingleton<IConsumer<Null, string>>(provider =>
{
    var config = new ConsumerConfig { GroupId = Constants.Kafka.GroupId, BootstrapServers = Constants.Kafka.BootstrapServers, AutoOffsetReset = AutoOffsetReset.Earliest };
    return new ConsumerBuilder<Null, string>(config).Build();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification API", Version = "v1", Description = "API for sending notifications using SignalR" });
});

builder.Services.AddHostedService<KafkaProducerService>();
builder.Services.AddHostedService<KafkaConsumerService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<NotificationHub>(Constants.SignalR.NotificationHub);
});

var notificationContext = app.Services.GetService<NotificationContext>();
notificationContext!.EnsureSeedData();

app.Run();
