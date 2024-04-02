namespace EmpowerID.Posts.Domain
{
    public class Post : AggregateRoot<PostId>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public static Post Create(PostData postData)
        {
            var (Title, Content, CreatedAt, Comments) = postData
                ?? throw new ArgumentNullException(nameof(postData));

            if (string.IsNullOrWhiteSpace(Title))
                throw new BusinessRuleException("Title cannot be null or whitespace.");
            if (string.IsNullOrWhiteSpace(Content))
                throw new BusinessRuleException("Content cannot be null or whitespace.");
            if (Comments != null)
                throw new BusinessRuleException("Comments cannot be null.");

            return new Post(postData);
        }

        private Post(PostData postData)
        {
            Id = PostId.Of(Guid.NewGuid());
            Title = postData.Title;
            Content = postData.Content;
            CreatedAt = DateTime.UtcNow;
            Comments = postData.Comments;
        }
        // Constructor
        public Post(PostId id,string title, string content, DateTime createdAt)
        {
            Id = id;
            SetTitle(title);
            SetContent(content);
            CreatedAt = createdAt;
            AggregateId = id.Value;
            Comments = new List<Comment>();
        }
        // Method to set title
        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new BusinessRuleException("Title cannot be null or whitespace.");
            Title = title;
        }
        // Method to set content
        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new BusinessRuleException("Content cannot be null or whitespace.");
            Content = content;
        }

        private Post() { }
    }
}
