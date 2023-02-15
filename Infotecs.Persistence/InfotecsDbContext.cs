#nullable disable

using Infotecs.Application.Interfaces;
using Infotecs.Domain;
using Infotecs.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infotecs.Persistence
{
    public class InfotecsDbContext : DbContext, IInfotecsDbContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Result> Results { get; set; }

        public InfotecsDbContext(DbContextOptions<InfotecsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ValueConfiguration());
            builder.ApplyConfiguration(new ResultConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
