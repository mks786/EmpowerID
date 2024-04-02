using System;
namespace EmpowerID.Posts.Domain
{
    public interface IComment
    {
        Task Add(Comment comment, CancellationToken cancellationToken = default);
        Task AddList(IList<Comment> comments, CancellationToken cancellationToken = default);
        Task<IEnumerable<Comment>> GetByIds(IList<CommentId> ids, CancellationToken cancellationToken = default);
        Task<IEnumerable<Comment>> ListAll(CancellationToken cancellationToken = default);
    }
}

