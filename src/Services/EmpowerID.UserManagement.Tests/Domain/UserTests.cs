namespace EmpowerID.UserManagement.Tests.Domain;

public class UserTests
{
    [Fact]
    public void CreatingUser_WithUserData_ShouldCreateUser()
    {
        // Given
        string email = "email@test.com";
        string name = "UserTest";
        string streetAddress = "Rue XYZ";

        var userData = new UserData(email, name, streetAddress);

        // When
        var user = User.Create(userData);

        // Then
        Assert.NotNull(user);
        user.Id.Value.Should().NotBe(Guid.Empty);
        user.Email.Should().Be(email);
        user.Name.Should().Be(name);
        user.UserAddress.Should().Be(Address.FromStreetAddress(streetAddress));
    }

    [Fact]
    public void UpdateInformation_WithChangingUserData_ShouldUpdateUserInformation()
    {
        // Given
        string email = "email@test.com";
        string name = "UserTest";
        string address = "Rue XYZ";

        var userData = new UserData(email, name, address);
        var user = User.Create(userData);

        var newName = "UserTestUpdated";
        var newAddress = "Rue X";
        userData = userData with 
        { 
            Name = newName,
            UserAddress = newAddress
        };

        // When
        user.UpdateInformation(userData);

        // Then
        Assert.NotNull(user);
        user.Id.Value.Should().NotBe(Guid.Empty);
        user.Email.Should().Be(email);
        user.Name.Should().Be(newName);
        user.UserAddress.Should().Be(Address.FromStreetAddress(newAddress));
    }
}