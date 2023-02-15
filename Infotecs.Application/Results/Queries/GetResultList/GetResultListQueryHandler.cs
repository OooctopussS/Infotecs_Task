using Infotecs.Application.Interfaces;
using Infotecs.Application.Values.Queries.GetValueList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Application.Results.Queries.GetResultList
{
    public class GetResultListQueryHandler : IRequestHandler<GetResultListQuery, ResultListVm>
    {
        private readonly IInfotecsDbContext _dbContext;
        public GetResultListQueryHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;

        public async Task<ResultListVm> Handle(GetResultListQuery request, CancellationToken cancellationToken)
        {
            var resultsQuery = await _dbContext.Results.ToListAsync(cancellationToken: cancellationToken);

            return new ResultListVm { Results = resultsQuery };
        }
    }
}
