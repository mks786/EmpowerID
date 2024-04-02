using EmpowerID.Core.Persistence;
using EmpowerID.Posts.Domain;

namespace EmpowerID.Posts.Application.Posts
{
    public class AddPostHandler : ICommandHandler<AddPostItem>
    {
        private readonly IPosts _posts;
        public AddPostHandler(IPosts posts)
        {
            _posts = posts;
        }

        public async Task Handle(AddPostItem command, CancellationToken cancellationToken)
        {
            // Create a new Post instance
            var post = new Post(PostId.Of(Guid.NewGuid()), command.Title, command.Content, command.CreatedAt);

            // Add the post to the repository
            await _posts.Add(post);
        }
    }
}
