namespace EmpowerID.Posts.Domain
{
    public class CommentId : StronglyTypedId<Guid>
    {
        public static CommentId Of(Guid value)
        {
            return new CommentId(value);
        }

        public static IEnumerable<CommentId> Of(IList<Guid> values)
        {
            foreach (var item in values)
                yield return Of(item);
        }

        public CommentId(Guid value) : base(value)
        {
        }
    }
}
