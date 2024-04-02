namespace EmpowerID.Posts.Application.Posts
{
    public record class GetPosts : IQuery<PostViewModel>
    {
        public PostId PostId { get; private set; }

        public static GetPosts Create(PostId postId)
        {
            if (postId is null)
                throw new ArgumentNullException(nameof(postId));

            return new GetPosts(postId);
        }

        private GetPosts(PostId postId)
        {
            PostId = postId;
        }
    }
}
