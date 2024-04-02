using EmpowerID.Core.Infrastructure.Integration;
using EmpowerID.Posts.Application.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Posts.Tests
{
    public class AddPostHandlerTests
    {
        [Fact]
        public async Task AddQuoteItem_WithCommand_ShouldAddQuoteItem()
        {
            // Arrange
            var postId = PostId.Of(Guid.NewGuid());
            var title = "AI Post Create Fact";
            var content = "AI Post Create Fact";

            var integrationHttpService = Substitute.For<IIntegrationHttpService>();
            var postWriteRepository = Substitute.For<IPosts>();

            var addPostHandler = new AddPostHandler(postWriteRepository);
            var command = new AddPostItem(title, content);

            // Act
            await addPostHandler.Handle(command, CancellationToken.None);

            // Assert
            await postWriteRepository.Received(1).Add(Arg.Any<Post>());
        }
    }
}
