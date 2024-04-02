using Marten;

namespace EmpowerID.Posts.Application.Posts
{
    public class GetPostsHandler : IQueryHandler<GetPosts, PostViewModel>
    {
        private readonly IPosts _posts;
        private readonly IIntegrationHttpService _integrationHttpService;
        private readonly IConfiguration _configuration;
        public GetPostsHandler(
        IPosts posts,
        IIntegrationHttpService integrationHttpService,
        IConfiguration configuration)
        {
            _integrationHttpService = integrationHttpService;
            _configuration = configuration;
            _posts = posts;
        }

        public async Task<PostViewModel> Handle(GetPosts query, CancellationToken cancellationToken)
        {
            var post = await _posts.GetById(query.PostId);

            if (post is null)
                throw new RecordNotFoundException("Unable to Find Post with Given Id");

            var commentviewModel =  post.Comments?.Select(comment =>
                    new CommentViewModel
                    {
                        CommentId = comment.Id.Value,
                        Content = comment.Content,
                        CreatedAt = comment.CreatedAt
                    }).ToList();

            var viewModel = new PostViewModel
                {
                    PostId = post.Id.Value,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedAt = post.CreatedAt,
                    Comments = commentviewModel ?? new List<CommentViewModel>()
                };

            return viewModel;
        }

    }
}
