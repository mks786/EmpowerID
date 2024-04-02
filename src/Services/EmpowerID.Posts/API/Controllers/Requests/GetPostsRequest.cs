namespace EmpowerID.Posts.API.Controllers.Requests;

public record class GetPostsRequest
{
    [Required(ErrorMessage = "The {0} field is required.")]
    public Guid[] PostIds { get; init; }

}