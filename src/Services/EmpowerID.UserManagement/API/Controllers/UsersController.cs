namespace EmpowerID.UserManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UsersController : CustomControllerBase
{
    private ITokenRequester _tokenRequester { get; set; }

    public UsersController(
        ITokenRequester tokenRequester,
        ICommandBus commandBus,
        IQueryBus queryBus)
        : base(commandBus, queryBus)
    {
        _tokenRequester = tokenRequester;
    }

    /// <summary>
    /// Get user details using user's token
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = Roles.User, Policy = Policies.CanRead)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserDetails>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDetailsByUserToken(CancellationToken cancellationToken) =>
        await Response(
            GetUserDetailsWithToken.Create(
                await _tokenRequester.GetUserTokenFromHttpContextAsync()),
                cancellationToken
        );

    /// <summary>
    /// Register a new user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken) =>
        await Response(
            RegisterUser.Create(
                request.Email,
                request.Password,
                request.PasswordConfirm,
                request.Name,
                request.UserAddress
            ), cancellationToken
        );

    /// <summary>
    /// Update user's information
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut, Route("{userId:guid}")]
    [Authorize(Roles = Roles.User, Policy = Policies.CanWrite)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateInformation([FromRoute] Guid userId,
        [FromBody] UpdateUserRequest request, CancellationToken cancellationToken) =>
        await Response(
            UpdateUserInformation.Create(
                UserId.Of(userId),
                request.Name,
                request.UserAddress
            ), cancellationToken
        );

    /// <summary>
    /// Get user details | M2M only
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("{userId:guid}/details")]
    [Authorize(Policy = Policies.M2MAccess)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserDetails>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetDetailsByUserId([FromRoute] Guid userId,
        CancellationToken cancellationToken) =>
        await Response(
            GetUserDetails.Create(UserId.Of(userId)),
            cancellationToken
        );
}