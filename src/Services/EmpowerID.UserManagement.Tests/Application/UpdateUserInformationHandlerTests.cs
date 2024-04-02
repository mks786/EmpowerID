using EmpowerID.UserManagement.Api.Application.UpdatingUserInformation;

namespace EmpowerID.UserManagement.Tests.Application;

public class UpdateUserInformationHandlerTests
{
    [Fact]
    public async Task UpdateUserInformation_WithCommand_ShouldUpdateUserInformation()
    {
        // Given
        string email = "email@test.com";
        string name = "UserTest";
        string streetAddress = "Rue XYZ";

        var userWriteRepository = new DummyEventStoreRepository<User>();
        var userData = new UserData(email, name, streetAddress);
        var user = User.Create(userData);
        await userWriteRepository.AppendEventsAsync(user);

        var newName = "New Name";
        var newStreetAddress = "New UserAddress";
        var updateCommand = UpdateUserInformation
            .Create(user.Id, newName, newStreetAddress);
        var commandHandler = new UpdateUserInformationHandler(userWriteRepository);

        // When
        await commandHandler.Handle(updateCommand, CancellationToken.None);
        var updatedUser = await userWriteRepository.FetchStreamAsync(user.Id.Value);

        // Then
        updatedUser.Name.Should().Be(newName);
        updatedUser.UserAddress.Should().Be(Address.FromStreetAddress(newStreetAddress));
    }
}