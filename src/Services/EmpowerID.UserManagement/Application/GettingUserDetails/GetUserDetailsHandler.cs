namespace EmpowerID.UserManagement.Api.Application.GettingUserDetails;

public class GetUserDetailsHandler : IQueryHandler<GetUserDetails, UserDetails>
{
    private readonly IQuerySession _querySession;

    public GetUserDetailsHandler(        
        IQuerySession querySession)
    {        
        _querySession = querySession;
    }

    public async Task<UserDetails> Handle(GetUserDetails query, 
        CancellationToken cancellationToken)
    {
        var user = await _querySession.Query<UserDetails>()
            .FirstOrDefaultAsync(c => c.Id == query.UserId.Value)
            ?? throw new RecordNotFoundException($"User not found.");

        var details = new UserDetails();
        details.Id = user.Id;
        details.Email = user.Email;
        details.Name = user.Name;
        details.UserAddress = user.UserAddress;

        return details;
    }
}
