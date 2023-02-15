using Infotecs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infotecs.Persistence.EntityTypeConfiguration
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(result => result.Id);
            builder.HasIndex(result => result.Id).IsUnique();

            builder.Property(result => result.MinDateAndTime).HasColumnType("datetime");
        }
    }
}
