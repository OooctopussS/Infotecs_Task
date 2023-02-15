using MediatR;

namespace Infotecs.Application.Values.Queries.GetValueList
{
    public class GetValueListQuery : IRequest<ValueListVm>
    {
        public string? FileName { get; set; }
    }
}
