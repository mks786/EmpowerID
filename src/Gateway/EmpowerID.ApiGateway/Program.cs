var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddJwtAuthentication(builder.Configuration);
services.AddHealthChecks();

// Ocelot
builder.Configuration.AddJsonFile("ocelot.json");
services.AddOcelot(builder.Configuration)
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    });

// Cors
services.AddCors(o =>
    o.AddPolicy("CorsPolicy", builder => {
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(x => true)
        .WithOrigins("http://localhost:4200");
    }
));

// App
var app = builder.Build();
app.UseWebSockets();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks();
app.UseOcelot().Wait();
app.Run();