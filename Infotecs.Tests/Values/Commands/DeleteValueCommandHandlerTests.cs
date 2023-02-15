using Infotecs.Application.Values.Commands.DeleteValue;
using Infotecs.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Tests.Values.Commands
{
    public class DeleteValueCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteValueCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteValueCommandHandler(Context);
            var fileName = InfotecsContextFactory.ThirdFileName;

            // Act
            await handler.Handle(new DeleteValueCommand
            {
                FileName = fileName
            }, CancellationToken.None);
            
            // Assert
            Assert.Null(Context.Values.SingleOrDefault(value =>
            value.FileName == fileName));
        }

        [Fact]
        public async Task DeleteValueCommandHandler_SuccessOnWrongFileName()
        {
            // Arrange
            var handler = new DeleteValueCommandHandler(Context);
            var fileName = "553453.csv";


            // Act
            await handler.Handle(new DeleteValueCommand
            {
                FileName = fileName
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Values.SingleOrDefault(value =>
            value.FileName == fileName));
        }
    }
}
