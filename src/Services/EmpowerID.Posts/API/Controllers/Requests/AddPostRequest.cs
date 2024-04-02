namespace EmpowerID.Posts.API.Controllers.Requests
{
    public record class AddPostRequest
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Content { get; init; }

    }
}
