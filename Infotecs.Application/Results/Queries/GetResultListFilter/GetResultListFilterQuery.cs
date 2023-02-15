using Infotecs.Application.Results.Queries.GetResultList;
using Infotecs.Domain;
using MediatR;

namespace Infotecs.Application.Results.Queries.GetResultListFilter
{
    public class GetResultListFilterQuery : IRequest<ResultListVm>
    {
        public string? FileName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? SecondsLowerBoundle { get; set; }
        public int? SecondsUpperBoundle { get; set; }
        public float? IndicatorLowerBoundle { get; set; }
        public float? IndicatorUpperBoundle { get; set; }
    }
}
