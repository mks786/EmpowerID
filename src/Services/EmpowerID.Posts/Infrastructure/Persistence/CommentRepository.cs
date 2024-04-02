namespace EmpowerID.Posts.Infrastructure.Persistence
{
    public class CommentRepository : IComment
    {
        private readonly PostsDbContext _context;

        public CommentRepository(PostsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Comment comment, CancellationToken cancellationToken = default)
        {
            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddList(IList<Comment> comments, CancellationToken cancellationToken = default)
        {
            await _context.Comments.AddRangeAsync(comments, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Comment>> GetByIds(IList<CommentId> ids, CancellationToken cancellationToken = default)
        {
            return await _context.Comments
                .Where(comment => ids.Contains(comment.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Comment>> ListAll(CancellationToken cancellationToken = default)
        {
            return await _context.Comments.ToListAsync(cancellationToken);
        }
    }
}
