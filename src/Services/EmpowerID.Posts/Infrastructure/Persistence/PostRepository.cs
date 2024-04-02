using EmpowerID.Posts.Domain;

namespace EmpowerID.Posts.Infrastructure.Persistence
{
    public class PostRepository : IPosts
    {
        private readonly PostsDbContext _context;

        public PostRepository(PostsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Post post, CancellationToken cancellationToken = default)
        {
            await _context.Posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddList(IList<Post> posts, CancellationToken cancellationToken = default)
        {
            await _context.Posts.AddRangeAsync(posts, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Post> GetById(PostId postId, CancellationToken cancellationToken = default)
        {
            return await _context.Posts
            .Include(post => post.Comments)
            .Where(post => post.AggregateId == postId.Value)
            .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Post>> ListAll(CancellationToken cancellationToken = default)
        {
            return await _context.Posts.ToListAsync(cancellationToken);
        }
    }
}
