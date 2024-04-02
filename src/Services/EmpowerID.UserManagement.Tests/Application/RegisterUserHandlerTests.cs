namespace EmpowerID.UserManagement.Tests.Application;

public class RegisterUserHandlerTests
{
    public RegisterUserHandlerTests()
    {
        _options.Value
            .Returns(new TokenIssuerSettings() { Authority = "http://url" });

        _requester.PostAsync<IntegrationHttpResponse>(Arg.Any<string>(), Arg.Any<object>())!
           .Returns(Task.FromResult(new IntegrationHttpResponse() { Success = true }));
    }

    [Fact]
    public async Task Register_WithCommand_ShouldRegisterUser()
    {
        // Given
        _checker.IsUnique(Arg.Any<string>())
            .Returns(true);

        var confirmation = _password;
        var registerCommand = RegisterUser
            .Create(_email, _password, confirmation, _name, _streetAddress);
        var commandHandler = new RegisterUserHandler(
            _requester,
            _checker,
            _options,
            _dummyRepository);

        // When
        await commandHandler.Handle(registerCommand, CancellationToken.None);

        // Then
        var addedUser = _dummyRepository.AggregateStream.First().Aggregate;
        addedUser.Email.Should().Be(registerCommand.Email);
        addedUser.Name.Should().Be(registerCommand.Name);
        addedUser.UserAddress.Should().Be(Address.FromStreetAddress(_streetAddress));
    }

    [Fact]
    public async Task Register_WithExistingEmail_ShouldThrownException()
    {
        // Given       
        _checker.IsUnique(Arg.Any<string>())
            .Returns(false);

        var confirmation = _password;
        var registerCommand = RegisterUser
            .Create(_email, _password, confirmation, _name, _streetAddress);
        var commandHandler = new RegisterUserHandler(
            _requester,
            _checker,
            _options,
            _dummyRepository);

        // When
        Func<Task> action = async () =>
            await commandHandler.Handle(registerCommand, CancellationToken.None);

        // Then
        await action.Should().ThrowAsync<BusinessRuleException>();
    }

    public const string _email = "email@test.com";
    public const string _name = "UserTest";
    public const string _password = "p4ssw0rd";
    public const string _streetAddress = "Rue XYZ";
    private IHttpRequester _requester = Substitute.For<IHttpRequester>();
    private IEmailUniquenessChecker _checker = Substitute.For<IEmailUniquenessChecker>();
    private IOptions<TokenIssuerSettings> _options = Substitute.For<IOptions<TokenIssuerSettings>>();
    private DummyEventStoreRepository<User> _dummyRepository = new DummyEventStoreRepository<User>();
}