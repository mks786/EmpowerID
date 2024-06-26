﻿namespace EmpowerID.Core.Infrastructure.Marten;

public interface IEventHistory
{
    Guid Id { get; init; }
    Guid AggregateId { get; init; }
    string EventTypeName { get; init; }
    string EventData { get; init; }
    DateTime Timestamp { get; init; }
}