using System.Xml.Linq;

namespace EmpowerID.Posts.Domain
{
    public class Comment : AggregateRoot<CommentId>
    {
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key property
        public PostId PostId { get; set; }

        // Navigation property for the associated post
        public Post Post { get; set; }

        public static Comment Create(CommentData postData)
        {
            var (Content, CreatedBy, CreatedAt, PostId) = postData
                ?? throw new ArgumentNullException(nameof(postData));

            if (string.IsNullOrWhiteSpace(Content))
                throw new BusinessRuleException("Content cannot be null or whitespace.");
            if (PostId != null)
                throw new BusinessRuleException("PostId cannot be null or whitespace.");

            return new Comment(postData);
        }

        private Comment(CommentData postData)
        {
            Id = CommentId.Of(Guid.NewGuid());
            Content = postData.Content;
            CreatedBy = postData.CreatedBy;
            CreatedAt = DateTime.UtcNow;
            PostId = postData.PostId;
        }

        private Comment() { }
    }
}
