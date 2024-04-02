namespace EmpowerID.UserManagement.Application.RegisteringUser;

public class EmailUniquenessChecker : IEmailUniquenessChecker
{
    private readonly IQuerySession _querySession;

    public EmailUniquenessChecker(IQuerySession querySession)
    {
        _querySession = querySession;
    }

    public bool IsUnique(string userEmail)
    {
        var user = _querySession.Query<UserDetails>()
            .FirstOrDefault(c => c.Email == userEmail);

        return user is null;
    }
}