namespace EmpowerID.UserManagement.Domain.Commands;

public record class RegisterUser : ICommand
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string PasswordConfirm { get; private set; }
    public string Name { get; private set; }
    public string UserAddress { get; private set; }

    public static RegisterUser Create(
        string email,
        string password,
        string passwordConfirm,
        string name,
        string address)
    {        
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));
        if (string.IsNullOrEmpty(passwordConfirm))
            throw new ArgumentNullException(nameof(passwordConfirm));
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrEmpty(address))
            throw new ArgumentNullException(nameof(address));

        return new RegisterUser(email,
            password,
            passwordConfirm,
            name,
            address);
    }

    private RegisterUser(
        string email,
        string password,
        string passwordConfirm,
        string name,
        string address)
    {
        Email = email;
        Password = password;
        PasswordConfirm = passwordConfirm;
        Name = name;
        UserAddress = address;
    }
}