using Infotecs.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Application.Interfaces
{
    public interface IInfotecsDbContext
    {
        DbSet<Value> Values { get; set; }

        DbSet<Result> Results { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
