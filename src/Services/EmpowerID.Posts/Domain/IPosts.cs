using System;
namespace EmpowerID.Posts.Domain
{
    public interface IPosts
    {
        Task Add(Post post, CancellationToken cancellationToken = default);
        Task AddList(IList<Post> posts, CancellationToken cancellationToken = default);
        Task<Post> GetById(PostId postId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Post>> ListAll(CancellationToken cancellationToken = default);
    }
}

