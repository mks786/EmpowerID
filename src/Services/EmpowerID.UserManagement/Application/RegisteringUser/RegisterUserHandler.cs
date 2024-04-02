namespace EmpowerID.UserManagement.Api.Application.RegisteringUser;

public class RegisterUserHandler : ICommandHandler<RegisterUser>
{
    private readonly IHttpRequester _httpRequester;
    private readonly IEmailUniquenessChecker _uniquenessChecker;
    private readonly TokenIssuerSettings _tokenIssuerSettings;
    private readonly IEventStoreRepository<User> _userWriteRepository;

    public RegisterUserHandler(
        IHttpRequester httpRequester,
        IEmailUniquenessChecker uniquenessChecker,
        IOptions<TokenIssuerSettings> tokenIssuerSettings,        
        IEventStoreRepository<User> userWriteRepository)
    {
        _httpRequester = httpRequester;
        _uniquenessChecker = uniquenessChecker;
        _tokenIssuerSettings = tokenIssuerSettings.Value;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Handle(RegisterUser command, CancellationToken cancellationToken)
    {
        if (!_uniquenessChecker.IsUnique(command.Email))
            throw new BusinessRuleException("This e-mail is already in use.");

        var userData = new UserData(
            command.Email,
            command.Name,
            command.UserAddress);

        var user = User.Create(userData);
        var response = await CreateUserForUser(command)
            ?? throw new RecordNotFoundException($"An error occurred creating the user's user.");

        if (!response.Success)
            throw new RecordNotFoundException(response.Message);

        await _userWriteRepository
            .AppendEventsAsync(user);
    }

    private async Task<IntegrationHttpResponse> CreateUserForUser(RegisterUser command)
    {
        try
        {
            var identityServerCreateUserUrl = $"{_tokenIssuerSettings.Authority}/api/accounts/register";
            var result = await _httpRequester
                .PostAsync<IntegrationHttpResponse>(identityServerCreateUserUrl,
                new RegisterUserRequest(
                    command.Email, 
                    command.Password, 
                    command.PasswordConfirm));

            return result;
        }
        catch (Exception e)
        {
            throw new RecordNotFoundException(e.Message);
        }
    }

    private record RegisterUserRequest(string Email, string Password, string PasswordConfirm);
}