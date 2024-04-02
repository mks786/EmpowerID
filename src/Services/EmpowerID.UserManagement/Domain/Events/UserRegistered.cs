namespace EmpowerID.UserManagement.Domain.Events;

public record class UserRegistered : DomainEvent
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string UserAddress { get; private set; }

    public static UserRegistered Create(
        Guid userId,
        string name,
        string email,
        string address)
    {      
        if (userId == Guid.Empty)
            throw new ArgumentOutOfRangeException(nameof(userId));
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrEmpty(address))
            throw new ArgumentNullException(nameof(address));

        return new UserRegistered(
            userId, 
            name, 
            email, 
            address);            
    }

    private UserRegistered(
        Guid userId,
        string name,
        string email,
        string address)
    {
        UserId = userId;
        Name = name;
        Email = email;
        UserAddress = address;
    }
}