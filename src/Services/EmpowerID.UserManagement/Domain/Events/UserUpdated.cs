namespace EmpowerID.UserManagement.Domain.Events;

public record class UserUpdated : DomainEvent
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string UserAddress { get; private set; }

    public static UserUpdated Create(
        Guid userId,
        string name, 
        string address)
    {        
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));        
        if (string.IsNullOrEmpty(address))
            throw new ArgumentNullException(nameof(address));

        return new UserUpdated(
            userId, 
            name, 
            address);
    }

    private UserUpdated(
        Guid userId,
        string name,
        string address)
    {
        UserId = userId;
        Name = name;
        UserAddress = address;
    }
}