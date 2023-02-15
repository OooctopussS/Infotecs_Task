using Infotecs.Application.Values.Commands.CreateValue;
using Infotecs.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Tests.Values.Commands
{
    public class CreateValueCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateValueCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateValueCommandHandler(Context);
            var fileName = InfotecsContextFactory.ThirdFileName;
            var dateAndTime = new DateTime(2019, 1, 1, 8, 5, 4);
            var seconds = 2048;
            var indicator = 36.78f;

            // Act
           var valueId = await handler.Handle(
                new CreateValueCommand
                {
                    FileName = fileName,
                    DateAndTime = dateAndTime,
                    Seсonds = seconds,
                    Indicator = indicator
                },

                CancellationToken.None
            );

            // Assert
            Assert.NotNull(
                await Context.Values.SingleOrDefaultAsync(value =>
                value.Id == valueId && value.FileName == fileName
                && value.DateAndTime == dateAndTime && value.Seсonds == seconds
                && value.Indicator == indicator));
        }
    }
}
