namespace EmpowerID.Core.EventBus;

public interface IIntegrationEvent : INotification {
    public Guid Id { get; }
}
