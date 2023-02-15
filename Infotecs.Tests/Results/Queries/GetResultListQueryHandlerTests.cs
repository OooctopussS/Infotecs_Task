using Infotecs.Application.Results.Queries.GetResultList;
using Infotecs.Tests.Common;
using Shouldly;

namespace Infotecs.Tests.Results.Queries
{
    public class GetResultListQueryHandlerTests : TestQueryBase
    {
        [Fact]
        public async void GetResultListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetResultListQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetResultListQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ResultListVm>();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
        }
    }
}
