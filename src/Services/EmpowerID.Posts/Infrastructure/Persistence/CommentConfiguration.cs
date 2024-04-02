namespace EmpowerID.Posts.Infrastructure.Persistence
{
    internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(
                    v => v.Value,
                    v => CommentId.Of(v));

            builder.Ignore(t => t.Version);

            builder.Property(e => e.Content)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            // Define the many-to-one relationship with Post
            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .IsRequired();
        }
    }
}