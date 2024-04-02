namespace EmpowerID.UserManagement.Tests.Domain;

public class UserEventsTests
{
    [Fact]
    public void Create_WithUserData_ShouldApplyUserRegisteredEvent()
    {
        // Given
        var userData = new UserData(_email, _name, _address);

        // When
        var user = User.Create(userData);

        // Then
        var @event = user.GetUncommittedEvents().LastOrDefault() as UserRegistered;
        Assert.NotNull(@event);
        @event.Should().BeOfType<UserRegistered>();
    }

    [Fact]
    public void UpdateInformation_WithUserData_ShouldApplyUserUpdatedEvent()
    {
        // Given
        var userData = new UserData(_email, _name, _address);
        var user = User.Create(userData);

        // When
        user.UpdateInformation(userData);

        // Then
        var @event = user.GetUncommittedEvents().LastOrDefault() as UserUpdated;
        Assert.NotNull(@event);
        @event.Should().BeOfType<UserUpdated>();
    }

    private const string _email = "email@test.com";
    private const string _name = "UserTest";
    private const string _address = "Rue XYZ";
}