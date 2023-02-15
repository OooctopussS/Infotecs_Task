using Infotecs.Application.Interfaces;
using Infotecs.Application.Results.Queries.GetResultList;
using Infotecs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Application.Results.Queries.GetResultListFilter
{
    public class GetResultListFilterQueryHandler : IRequestHandler<GetResultListFilterQuery, ResultListVm>
    {
        private readonly IInfotecsDbContext _dbContext;
        public GetResultListFilterQueryHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;

        public async Task<ResultListVm> Handle(GetResultListFilterQuery request, CancellationToken cancellationToken)
        {
            DateTime? FromDate = null, ToDate = null;
            int? SecondsLowwerBoundle, SecondsUpperBoundle;
            float? IndicatorLowwerBoundle, IndicatorUpperBoundle;

            if (request.FromDate != null && request.ToDate != null)
            {
                FromDate = request.FromDate;
                ToDate = request.ToDate;
            }
            else
            {
                FromDate = new DateTime(1999, 1, 1);
                ToDate = new DateTime(3000, 1, 1);
            }

            if (request.SecondsLowerBoundle != null && request.SecondsUpperBoundle!= null)
            {
                SecondsLowwerBoundle = request.SecondsLowerBoundle;
                SecondsUpperBoundle = request.SecondsUpperBoundle;
            }
            else
            {
                SecondsLowwerBoundle = 0;
                SecondsUpperBoundle = int.MaxValue;
            }

            if (request.IndicatorLowerBoundle != null && request.IndicatorUpperBoundle != null)
            {
                IndicatorLowwerBoundle = request.IndicatorLowerBoundle;
                IndicatorUpperBoundle = request.IndicatorUpperBoundle;
            }
            else
            {
                IndicatorLowwerBoundle = 0;
                IndicatorUpperBoundle = float.MaxValue;
            }

            List<Result> resultsQuery;

            if (request.FileName != null)
            {
                resultsQuery = await _dbContext.Results
                    .Where(r => r.FileName == request.FileName)
                    .Where(r => r.MinDateAndTime >= FromDate && r.MinDateAndTime <= ToDate)
                    .Where(r => r.AvgSeсonds >= SecondsLowwerBoundle && r.AvgSeсonds <= SecondsUpperBoundle)
                    .Where(r => r.AvgIndicator >= IndicatorLowwerBoundle && r.AvgIndicator <= IndicatorUpperBoundle)
                    .ToListAsync(cancellationToken);
            }
            else
            {
                resultsQuery = await _dbContext.Results
                    .Where(r => r.MinDateAndTime >= FromDate && r.MinDateAndTime <= ToDate)
                    .Where(r => r.AvgSeсonds >= SecondsLowwerBoundle && r.AvgSeсonds <= SecondsUpperBoundle)
                    .Where(r => r.AvgIndicator >= IndicatorLowwerBoundle && r.AvgIndicator <= IndicatorUpperBoundle)
                    .ToListAsync(cancellationToken);
            }
            


            return new ResultListVm { Results = resultsQuery };
        }
    }
}
