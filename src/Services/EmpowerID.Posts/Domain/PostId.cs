namespace EmpowerID.Posts.Domain
{
    public sealed class PostId : StronglyTypedId<Guid>
    {
        public static PostId Of(Guid value)
        {
            return new PostId(value);
        }

        public static IEnumerable<PostId> Of(IList<Guid> values)
        {
            foreach (var item in values)
                yield return Of(item);
        }

        public PostId(Guid value) : base(value)
        {
        }
    }
}
