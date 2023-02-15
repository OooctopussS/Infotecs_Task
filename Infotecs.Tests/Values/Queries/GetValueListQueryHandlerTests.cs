using Infotecs.Application.Values.Queries.GetValueList;
using Infotecs.Tests.Common;
using Shouldly;

namespace Infotecs.Tests.Values.Queries
{
    public class GetValueListQueryHandlerTests : TestQueryBase
    {
        [Fact]
        public async void GetValueListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetValueListQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetValueListQuery
                {
                    FileName = InfotecsContextFactory.FirstFileName
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ValueListVm>();
            result.Values.ShouldNotBeNull();
            result.Values.Count.ShouldBe(2);
        }
    }
}
