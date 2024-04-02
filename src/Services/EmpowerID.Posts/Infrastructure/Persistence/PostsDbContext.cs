using System;
namespace EmpowerID.Posts.Infrastructure.Persistence
{
	public class PostsDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostsDbContext).Assembly);
        }
    }
}