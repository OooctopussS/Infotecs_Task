using MediatR;

namespace Infotecs.Application.Results.Commands.DeleteResult
{
    public class DeleteResultCommand : IRequest
    {
        public string FileName { get; set; } = null!;

    }
}
