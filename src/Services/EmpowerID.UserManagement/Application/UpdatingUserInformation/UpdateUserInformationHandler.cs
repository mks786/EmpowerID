namespace EmpowerID.UserManagement.Api.Application.UpdatingUserInformation;

public class UpdateUserInformationHandler : ICommandHandler<UpdateUserInformation>
{
    private readonly IEventStoreRepository<User> _userWriteRepository;

    public UpdateUserInformationHandler(
        IEventStoreRepository<User> userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public async Task Handle(UpdateUserInformation command, CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository
            .FetchStreamAsync(command.UserId.Value)
            ?? throw new ArgumentNullException($"User {command.UserId.Value} not found.");

        var userData = new UserData(
            user.Email,
            command.Name,
            command.UserAddress);

        user.UpdateInformation(userData);

        await _userWriteRepository
            .AppendEventsAsync(user, cancellationToken);
    }
}

public record UpdateUserRequest(
    string Email, 
    string Password, 
    string PasswordConfirm);