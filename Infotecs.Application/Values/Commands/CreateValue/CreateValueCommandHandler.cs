using Infotecs.Application.Interfaces;
using Infotecs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Application.Values.Commands.CreateValue
{
    public class CreateValueCommandHandler : IRequestHandler<CreateValueCommand, Guid>
    {
        private readonly IInfotecsDbContext _dbContext;

        public CreateValueCommandHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateValueCommand request, CancellationToken cancellationToken)
        {
            var value = new Value
            {
                Id = Guid.NewGuid(),
                FileName = request.FileName,
                DateAndTime = request.DateAndTime,
                Seсonds = request.Seсonds,
                Indicator = request.Indicator
            };

            

            await _dbContext.Values.AddAsync(value, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return value.Id;
        }
    }
}
