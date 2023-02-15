using MediatR;

namespace Infotecs.Application.Values.Commands.CreateValue
{
    public class CreateValueCommand : IRequest<Guid>
    {
        public string FileName { get; set; } = null!;
        public DateTime DateAndTime { get; set; }
        public int Seсonds { get; set; }
        public float Indicator { get; set; }
    }
}
