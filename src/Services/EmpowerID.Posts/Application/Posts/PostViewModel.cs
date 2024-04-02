namespace EmpowerID.Posts.Application.Posts
{
    public class PostViewModel()
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentViewModel>? Comments { get; set; }
    }
    public record class CommentViewModel
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
