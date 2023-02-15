using Infotecs.Application.Interfaces;
using Infotecs.Application.Common.Exceptions;
using Infotecs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Application.Values.Commands.DeleteValue
{
    public class DeleteValueCommandHandler : IRequestHandler<DeleteValueCommand>
    {
        private readonly IInfotecsDbContext _dbContext;

        public DeleteValueCommandHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteValueCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Values.Where(value => value.FileName == request.FileName).ForEachAsync(value =>
            {
                _dbContext.Values.Remove(value);
            }, cancellationToken: cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
