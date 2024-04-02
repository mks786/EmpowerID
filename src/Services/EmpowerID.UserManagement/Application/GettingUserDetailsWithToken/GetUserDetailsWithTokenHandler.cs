namespace EmpowerID.UserManagement.Api.Application.GettingUserDetailsWithToken;

public class GetUserDetailsWithTokenHandler : IQueryHandler<GetUserDetailsWithToken, UserDetails>
{
    private readonly TokenIssuerSettings _tokenIssuerSettings;
    private readonly IQuerySession _querySession;
    private readonly IHttpRequester _requester;

    public GetUserDetailsWithTokenHandler(
        IOptions<TokenIssuerSettings> tokenIssuerSettings,
        IHttpRequester httpRequester,
        IQuerySession querySession)
    {
        _tokenIssuerSettings = tokenIssuerSettings.Value;
        _requester = httpRequester;
        _querySession = querySession;
    }

    public async Task<UserDetails> Handle(GetUserDetailsWithToken query, 
        CancellationToken cancellationToken)
    {
        var uri = $"{_tokenIssuerSettings.Authority}/connect/userinfo";

        var response = await _requester
            .GetAsync<UserInfoResponse>(uri, query.UserAccessToken)
            ?? throw new RecordNotFoundException($"Cannot retrieve user user info.");

        var details = new UserDetails();
        var user = _querySession.Query<UserDetails>()
            .FirstOrDefault(c => c.Email == response.Email)
            ?? throw new RecordNotFoundException($"User not found.");

        details.Id = user.Id;
        details.Email = user.Email;
        details.Name = user.Name;
        details.UserAddress = user.UserAddress;

        return details;
    }

    public record class UserInfoResponse(string Email);
}
