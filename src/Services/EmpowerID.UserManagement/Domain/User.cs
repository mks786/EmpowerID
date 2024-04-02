using static Duende.IdentityServer.Models.IdentityResources;

namespace EmpowerID.UserManagement.Domain;

public sealed class User : AggregateRoot<UserId>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Address UserAddress { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static User Create(UserData userData)
    {
        var (Email, Name, UserAddress) = userData
            ?? throw new ArgumentNullException(nameof(userData));

        if (string.IsNullOrWhiteSpace(Email))
            throw new BusinessRuleException("User email cannot be null or whitespace.");

        if (string.IsNullOrWhiteSpace(Name))
            throw new BusinessRuleException("User name cannot be null or whitespace.");

        if (string.IsNullOrWhiteSpace(UserAddress))
            throw new BusinessRuleException("User shipping address cannot be null or whitespace.");

        return new User(userData);
    }

    public void UpdateInformation(UserData userData)
    {
        var (Email, Name, UserAddress) = userData
            ?? throw new ArgumentNullException(nameof(userData));

        if (string.IsNullOrWhiteSpace(userData.Name))
            throw new BusinessRuleException("User name cannot be null or whitespace.");

        if (string.IsNullOrWhiteSpace(UserAddress))
            throw new BusinessRuleException("User shipping address cannot be null or whitespace.");

        var @event = UserUpdated.Create(
            Id.Value,
            Name,
            UserAddress);

        AppendEvent(@event);
        Apply(@event);
    }

    private void Apply(UserRegistered @event)
    {
        Id = UserId.Of(@event.UserId);
        Email = @event.Email;
        Name = @event.Name;
        UserAddress = Address.FromStreetAddress(@event.UserAddress);
        RegisteredAt = @event.Timestamp;
    }

    private void Apply(UserUpdated @event)
    {
        Name = @event.Name;
        UserAddress = Address.FromStreetAddress(@event.UserAddress);
        UpdatedAt = @event.Timestamp;
    }

    private User(UserData userData)
    {
        var @event = UserRegistered.Create(
            Guid.NewGuid(),
            userData.Name,
            userData.Email,
            userData.UserAddress);

        AppendEvent(@event);
        Apply(@event);
    }

    private User() {}
}