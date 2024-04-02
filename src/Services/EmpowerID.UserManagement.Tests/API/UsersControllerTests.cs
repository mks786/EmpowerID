namespace EmpowerID.UserManagement.Tests;

public class UsersControllerTests
{
    public UsersControllerTests()
    {
        var fakeToken = "yJhbGciOiJSUzI1NiIsImtpZCI6IjAzOUI0NUE1OThCMzE3RTRBQzc0M";
        _tokenRequester.GetUserTokenFromHttpContextAsync()
            .Returns(fakeToken);

        _usersController = new UsersController(
            _tokenRequester,
            _commandBus,
            _queryBus);
    }

    [Fact]
    public async Task GetDetailsByUserToken_WithFakeToken_ShouldReturnGetUserDetails()
    {
        // Given
        var userId = Guid.NewGuid();
        var expectedData = new UserDetails
        {
            Id = userId,
            Email = "user@test.com",
            Name = "UserX",
            UserAddress = "Infinite loop street"
        };

        _queryBus.SendAsync(Arg.Any<GetUserDetailsWithToken>(), CancellationToken.None)
            .Returns(expectedData);

        // When
        var response = await _usersController.GetDetailsByUserToken(CancellationToken.None);

        // Then
        response.Should().BeOfType<OkObjectResult>()
            .Subject.Value.Should().BeOfType<ApiResponse<UserDetails>>()
            .Subject.Data.Should().BeEquivalentTo(expectedData);
    }

    

    

    [Fact]
    public async Task Register_RegisterUserRequest_ShouldRegisterUser()
    {
        // Given
        var request = new RegisterUserRequest()
        {
            Email = "user@test.com",
            Name = "UserX",
            Password = "p4$$w0rd",
            PasswordConfirm = "p4$$w0rd",
            UserAddress = "Infinite loop street"
        };

        await _commandBus.SendAsync(Arg.Any<RegisterUser>(), Arg.Any<CancellationToken>());

        // When
        var response = await _usersController.Register(request,
            Arg.Any<CancellationToken>());

        // Then
        response.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task UpdateInformation_RegisterUserRequest_ShouldUpdateInformation()
    {
        // Given
        var userId = Guid.NewGuid();
        var request = new UpdateUserRequest
        {
            Name = "UserX",
            UserAddress = "Infinite loop street"
        };

        await _commandBus.SendAsync(Arg.Any<RegisterUser>(), Arg.Any<CancellationToken>());

        // When
        var response = await _usersController.UpdateInformation(userId, request,
            Arg.Any<CancellationToken>());

        // Then
        response.Should().BeOfType<OkObjectResult>();
    }

    private UsersController _usersController;
    private ICommandBus _commandBus = Substitute.For<ICommandBus>();
    private IQueryBus _queryBus = Substitute.For<IQueryBus>();
    private ITokenRequester _tokenRequester = Substitute.For<ITokenRequester>();
}