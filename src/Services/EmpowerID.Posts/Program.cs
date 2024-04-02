using EmpowerID.Posts.Application.Posts;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.AppDatabaseSetup();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddCoreInfrastructure(builder.Configuration);
services.AddHealthChecks();

// Mediator        
services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetPostsHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetPostsHandler).Assembly);
    });

// Services
services.AddScoped<IPosts, PostRepository>();
services.AddScoped<IPosts, PostRepository>();
services.AddScoped<IComment, CommentRepository>();

// Policies
services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.M2MAccess, AuthPolicyBuilder.M2MAccess);
    options.AddPolicy(Policies.CanRead, AuthPolicyBuilder.CanRead);
    options.AddPolicy(Policies.CanWrite, AuthPolicyBuilder.CanWrite);
    options.AddPolicy(Policies.CanDelete, AuthPolicyBuilder.CanDelete);
});

// App
var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger(builder.Configuration);

// Seed posts
await app.SeedPostsAsync();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks();

app.Run();
