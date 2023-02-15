using MediatR;

namespace Infotecs.Application.Values.Commands.DeleteValue
{
    public class DeleteValueCommand : IRequest
    {
        public string FileName { get; set; } = null!;
    }
}
