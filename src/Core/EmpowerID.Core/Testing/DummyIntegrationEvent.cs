﻿namespace EmpowerID.Core.Testing;

public sealed class DummyIntegrationEvent : IIntegrationEvent
{
    public Guid Id => Guid.NewGuid();
}