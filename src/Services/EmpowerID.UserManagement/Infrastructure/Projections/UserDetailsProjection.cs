namespace EmpowerID.UserManagement.Infrastructure.Projections;

public class UserDetailsProjection : SingleStreamProjection<UserDetails>
{
    public UserDetailsProjection()
    {
        ProjectEvent<UserRegistered>((item, @event) => item.Apply(@event));
        ProjectEvent<UserUpdated>((item, @event) => item.Apply(@event));
    }
}

//https://martendb.io/events/projections/aggregate-projections.html#aggregate-by-stream