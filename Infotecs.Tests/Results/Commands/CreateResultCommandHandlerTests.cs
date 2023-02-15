using Infotecs.Application.Results.Commands.CreateResult;
using Infotecs.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Tests.Results.Commands
{
    public class CreateResultCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateResultCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateResultCommandHandler(Context);
            var fileName = InfotecsContextFactory.ThirdFileName;
            TimeSpan allTime = new(0, 0, 0);
            DateTime minDateAndTime = new(2019, 1, 1, 8, 5, 4);
            int avgSeсonds = 2048;
            float avgIndicator = 36.78f;
            float medianIndicator = 36.78f;
            float minIndicator = 36.78f;
            float maxIndicator = 36.78f;
            int countStrings = 1;

        // Act
        var valueId = await handler.Handle(
                 new CreateResultCommand
                 {
                     FileName = fileName,
                     AllTime = allTime,
                     MinDateAndTime = minDateAndTime,
                     AvgSeсonds = avgSeсonds,
                     AvgIndicator = avgIndicator,
                     MedianIndicator = medianIndicator,
                     MinIndicator = minIndicator,
                     MaxIndicator = maxIndicator,
                     CountStrings = countStrings,
                 },
                 CancellationToken.None
             );

            // Assert
            Assert.NotNull(
                await Context.Results.SingleOrDefaultAsync(value =>
                value.FileName == fileName && value.AllTime == allTime
                && value.MinDateAndTime == minDateAndTime && value.AvgSeсonds == avgSeсonds
                && value.AvgIndicator == avgIndicator && value.MedianIndicator == medianIndicator
                && value.MinIndicator == minIndicator && value.MaxIndicator == maxIndicator
                && value.CountStrings == countStrings));
        }
    }
}
