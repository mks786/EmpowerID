
namespace EmpowerID.Core.Testing;

public sealed class DummyDomainEvent : IDomainEvent
{
    public DateTime Timestamp => DateTime.UtcNow;
}