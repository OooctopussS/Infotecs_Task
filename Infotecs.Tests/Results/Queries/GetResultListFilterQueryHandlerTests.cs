using Infotecs.Application.Results.Queries.GetResultList;
using Infotecs.Application.Results.Queries.GetResultListFilter;
using Infotecs.Tests.Common;
using Shouldly;

namespace Infotecs.Tests.Results.Queries
{
    public class GetResultListFilterQueryHandlerTests : TestQueryBase
    {
        [Fact]
        public async void GetResultListFilterQueryHandler_SuccessOnFilterFileName()
        {
            // Arrange
            var handler = new GetResultListFilterQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetResultListFilterQuery
                {
                    FileName = InfotecsContextFactory.FirstFileName
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ResultListVm>();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(1);
        }

        [Fact]
        public async void GetResultListFilterQueryHandler_EmptyListOnWrongFileNameFilter()
        {
            // Arrange
            var handler = new GetResultListFilterQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetResultListFilterQuery
                {
                    FileName = "554545.csv"
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ResultListVm>();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(0);
        }

        [Fact]
        public async void GetResultListFilterQueryHandler_SuccessOnAvgSecondsAndAvgIndicatorFilter()
        {
            // Arrange
            var handler = new GetResultListFilterQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetResultListFilterQuery
                {
                    SecondsLowerBoundle = 900,
                    SecondsUpperBoundle = 1890,
                    IndicatorLowerBoundle = 1000.5f,
                    IndicatorUpperBoundle = 1500.9f
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ResultListVm>();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
        }
    }
}
