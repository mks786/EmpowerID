namespace EmpowerID.Posts.Infrastructure.Extensions;

public static class DatabaseSetupExtension
{
    public static WebApplicationBuilder AppDatabaseSetup(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        if (services is null)
            throw new ArgumentNullException(nameof(services));

        string connString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PostsDbContext>(options =>
        {
            options.UseSqlServer(connString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
        });
        return builder;
    }
}