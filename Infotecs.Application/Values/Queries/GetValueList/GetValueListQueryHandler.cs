using Infotecs.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Application.Values.Queries.GetValueList
{
    public class GetValueListQueryHandler : IRequestHandler<GetValueListQuery, ValueListVm>
    {
        private readonly IInfotecsDbContext _dbContext;
        public GetValueListQueryHandler(IInfotecsDbContext dbContext) => _dbContext = dbContext;

        public async Task<ValueListVm> Handle(GetValueListQuery request, CancellationToken cancellationToken)
        {
            var valuesQuery = await _dbContext.Values.Where(value => value.FileName == request.FileName).ToListAsync(cancellationToken);

            return new ValueListVm { Values = valuesQuery };
        }
    }
}
