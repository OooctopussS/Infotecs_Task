using Infotecs.Application.Interfaces;
using Infotecs.Domain;
using MediatR;


namespace Infotecs.Application.Results.Commands.CreateResult
{
    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, Guid>
    {
        private readonly IInfotecsDbContext _dbContext;

        public CreateResultCommandHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            var result = new Result
            {
                Id = Guid.NewGuid(),
                FileName = request.FileName,
                AllTime = request.AllTime,
                MinDateAndTime = request.MinDateAndTime,
                AvgSeсonds = request.AvgSeсonds,
                AvgIndicator = request.AvgIndicator,
                MedianIndicator = request.MedianIndicator,
                MinIndicator = request.MinIndicator,
                MaxIndicator = request.MaxIndicator,
                CountStrings = request.CountStrings,
            };

            await _dbContext.Results.AddAsync(result, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return result.Id;
        }
    }
}
