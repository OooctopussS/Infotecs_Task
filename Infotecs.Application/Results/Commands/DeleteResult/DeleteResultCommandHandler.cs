using Infotecs.Application.Common.Exceptions;
using Infotecs.Application.Interfaces;
using Infotecs.Domain;
using MediatR;

namespace Infotecs.Application.Results.Commands.DeleteResult
{
    public class DeleteResultCommandHandler : IRequestHandler<DeleteResultCommand>
    {
        private readonly IInfotecsDbContext _dbContext;

        public DeleteResultCommandHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteResultCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Results.FirstOrDefault(x => x.FileName == request.FileName);

            if (entity != null)
            {
                _dbContext.Results.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
