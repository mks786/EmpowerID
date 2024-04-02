namespace EmpowerID.Posts.Domain
{
    public class AddPostItem : ICommand
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static AddPostItem Create(
            string title,
            string content)
        {
            if (title is null)
                throw new ArgumentNullException(nameof(title));
            if (content is null)
                throw new ArgumentNullException(nameof(content));

            return new AddPostItem(title, content);
        }

        public AddPostItem(
            string title,
            string content)
        {
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
