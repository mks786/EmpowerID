namespace EmpowerID.Posts.Domain
{
    public record class CommentData(
    string Content,
    string CreatedBy,
    DateTime CreatedAt,
    PostId PostId);
}
