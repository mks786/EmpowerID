﻿using EmpowerID.Core.Infrastructure.Outbox;

namespace EmpowerID.Core.Infrastructure.Kafka;

public static class KafkaSetupExtension
{
    public static IServiceCollection AddKafkaConsumer(this IServiceCollection services,
        IConfiguration configuration)
    {
        var consumerConfig = configuration.GetSection("KafkaConsumer");
        services.Configure<KafkaConsumerConfig>(consumerConfig);
        services.AddSingleton(typeof(JsonEventSerializer<>));
        services.TryAddSingleton<IEventConsumer, KafkaConsumer>();
        return services.AddHostedService<KafkaBackgroundWorker>();
    }

    public static IServiceCollection AddKafkaConsumerAndDebezium(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .ConfigureDebezium(configuration)
            .AddKafkaConsumer(configuration);
    }
}