using Infotecs.Application.Results.Commands.DeleteResult;
using Infotecs.Tests.Common;

namespace Infotecs.Tests.Results.Commands
{
    public class DeleteResultCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteResultCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteResultCommandHandler(Context);
            var fileName = InfotecsContextFactory.ThirdFileName;

            // Act
            await handler.Handle(new DeleteResultCommand
            {
                FileName = fileName
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Results.SingleOrDefault(value =>
            value.FileName == fileName));
        }

        [Fact]
        public async Task DeleteResultCommandHandler_SuccessOnWrongFileName()
        {
            // Arrange
            var handler = new DeleteResultCommandHandler(Context);
            var fileName = "553453.csv";


            // Act
            await handler.Handle(new DeleteResultCommand
            {
                FileName = fileName
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Results.SingleOrDefault(value =>
            value.FileName == fileName));
        }
    }
}
