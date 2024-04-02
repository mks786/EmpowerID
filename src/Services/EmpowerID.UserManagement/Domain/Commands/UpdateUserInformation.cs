namespace EmpowerID.UserManagement.Domain.Commands;

public record class UpdateUserInformation : ICommand
{
    public UserId UserId { get; private set; }
    public string Name { get; private set; }
    public string UserAddress { get; private set; }

    public static UpdateUserInformation Create(
        UserId userId,
        string name,
        string address)
    {
        if (userId is null)
            throw new ArgumentNullException(nameof(userId));
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrEmpty(address))
            throw new ArgumentNullException(nameof(address));

        return new UpdateUserInformation(
            userId, 
            name, 
            address);
    }

    private UpdateUserInformation(
        UserId userId,
        string name,
        string address)
    {
        UserId = userId;
        Name = name;
        UserAddress = address;
    }
}
