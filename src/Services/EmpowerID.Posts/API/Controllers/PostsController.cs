using EmpowerID.Posts.Application.Posts;
using EmpowerID.Posts.Domain;

namespace EmpowerID.Posts.API.Controllers
{
    [ApiController]
    [Route("api/Posts")]
    [Authorize]
    public class PostsController : CustomControllerBase
    {
        public PostsController(
        ICommandBus commandBus,
        IQueryBus queryBus)
        : base(commandBus, queryBus) { }

        [HttpGet, Route("{postId:guid}")]
        [Authorize(Policy = Policies.CanRead)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PostViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListPost([FromRoute] Guid postId,
        CancellationToken cancellationToken) =>
        await Response(
        GetPosts.Create(PostId.Of(postId)),
             cancellationToken
        );

        /// <summary>
        /// Add a Post item
        /// </summary>
        /// <param name="quoteId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = Policies.CanWrite)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPost([FromBody] AddPostRequest request, CancellationToken cancellationToken) =>
            await Response(
                AddPostItem.Create(request.Title, request.Content), cancellationToken
           );
    }
}
