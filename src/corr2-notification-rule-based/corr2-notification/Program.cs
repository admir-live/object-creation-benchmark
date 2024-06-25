using Confluent.Kafka;
using corr2_notification;
using corr2_notification.Hubs;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj CORS politiku
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

// Dodaj usluge za SignalR i kontrolere
builder.Services.AddSignalR();
builder.Services.AddControllers();

// Dodaj Kafka producer konfiguraciju
builder.Services.AddSingleton<IProducer<Null, string>>(provider =>
{
    var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
    return new ProducerBuilder<Null, string>(config).Build();
});

// Dodaj Kafka consumer konfiguraciju
builder.Services.AddSingleton<IConsumer<Null, string>>(provider =>
{
    var config = new ConsumerConfig { GroupId = "notification-consumer-group", BootstrapServers = "localhost:9092", AutoOffsetReset = AutoOffsetReset.Earliest };
    return new ConsumerBuilder<Null, string>(config).Build();
});

// Dodaj Swagger usluge
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification API", Version = "v1", Description = "API for sending notifications using SignalR" });
});

// Dodaj background servise
builder.Services.AddHostedService<KafkaProducerService>();
builder.Services.AddHostedService<KafkaConsumerService>();

var app = builder.Build();

// Koristi CORS politiku
app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API V1");
        c.RoutePrefix = string.Empty; // Omogućava Swagger UI na root URL-u
    });
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<NotificationHub>("/hubs/notification");
});

app.Run();
