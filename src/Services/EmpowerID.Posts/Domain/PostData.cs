namespace EmpowerID.Posts.Domain
{
    public record class PostData(
    string Title,
    string Content,
    DateTime CreatedAt,
    ICollection<Comment>? Comments= null);
}
