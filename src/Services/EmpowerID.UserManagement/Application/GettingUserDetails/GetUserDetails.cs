namespace EmpowerID.UserManagement.Api.Application.GettingUserDetails;

public record class GetUserDetails : IQuery<UserDetails>
{
    public UserId UserId { get; private set; }

    public static GetUserDetails Create(UserId userId)
    {
        if (userId is null)
            throw new ArgumentNullException(nameof(userId));

        return new GetUserDetails(userId);
    }

    private GetUserDetails(UserId userId)
    {
        UserId = userId;
    }
}