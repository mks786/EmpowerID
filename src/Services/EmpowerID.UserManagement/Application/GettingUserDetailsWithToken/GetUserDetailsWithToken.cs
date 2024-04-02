namespace EmpowerID.UserManagement.Api.Application.GettingUserDetailsWithToken;

public record class GetUserDetailsWithToken : IQuery<UserDetails>
{
    public string UserAccessToken { get; private set; }

    public static GetUserDetailsWithToken Create(string userAccessToken)
    {
        if (string.IsNullOrEmpty(userAccessToken))
            throw new ArgumentNullException(nameof(userAccessToken));

        return new GetUserDetailsWithToken(userAccessToken);
    }

    private GetUserDetailsWithToken(string userAccessToken)
    {
        UserAccessToken = userAccessToken;
    }
}