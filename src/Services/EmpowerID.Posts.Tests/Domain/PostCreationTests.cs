using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Posts.Tests.Domain
{
    public class PostCreationTests
    {
        [Fact]
        public void Create_WithPostData_ReturnsPost()
        {
            // Given
            var title = "AI Fact";
            var Content = "Fact Content";
            var postData = new PostData(
                title,
                Content,
                DateTime.UtcNow);

            // When
            var post = Post.Create(postData);

            // Then
            Assert.NotNull(post);
            post.Id.Should().NotBe(null);
            post.Title.Should().Be(title);
            post.Content.Should().Be(Content);
        }
    }
}
