using System;
namespace EmpowerID.Posts.Infrastructure.Extensions
{
	public static class DataSeedExtension
	{
        private static IIntegrationHttpService _integrationHttpService;
        public static async Task<IApplicationBuilder> SeedPostsAsync(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetService<IServiceScopeFactory>()!
                .CreateScope() ??
                throw new NullReferenceException("Can't create scope factory.");

            _integrationHttpService = serviceScope.ServiceProvider.GetRequiredService<IIntegrationHttpService>();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<PostsDbContext>();

            try
            {
                var hasPosts = await dbContext.Posts.AnyAsync();
                if (!hasPosts)
                {
                    var posts = new List<Post>
                    {
                        new Post(PostId.Of(Guid.NewGuid()), "First Post", "This is the content of the first post.", DateTime.UtcNow),
                        new Post(PostId.Of(Guid.NewGuid()), "Second Post", "This is the content of the second post.", DateTime.UtcNow)
                    };

                    //posts[0].Comments.Add(new Comment(CommentId.Of(Guid.NewGuid()), "This is a comment on the first post.", "User1", DateTime.UtcNow, posts[0].Id));
                   //posts[1].Comments.Add(new Comment(CommentId.Of(Guid.NewGuid()), "This is a comment on the second post.", "User2", DateTime.UtcNow, posts[1].Id));

                }
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}