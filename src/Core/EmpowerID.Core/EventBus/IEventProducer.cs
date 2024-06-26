﻿namespace EmpowerID.Core.EventBus;

public interface IEventProducer
{
    Task PublishAsync(INotification @event, CancellationToken cancellationToken = default);
}