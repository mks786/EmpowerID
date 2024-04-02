namespace EmpowerID.UserManagement.Infrastructure.Projections;

public class UserDetails
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string UserAddress { get; set; }

    internal void Apply(UserRegistered registered)
    {
        Id = registered.UserId;
        Email = registered.Email;
        Name = registered.Name;
        UserAddress = registered.UserAddress;
    }

    internal void Apply(UserUpdated updated)
    {
        Name = updated.Name;
        UserAddress = updated.UserAddress;
    }
}