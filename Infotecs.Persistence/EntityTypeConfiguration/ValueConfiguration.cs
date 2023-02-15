using Infotecs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infotecs.Persistence.EntityTypeConfiguration
{
    public class ValueConfiguration : IEntityTypeConfiguration<Value>
    {
        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder.HasKey(value => value.Id);
            builder.HasIndex(value => value.Id).IsUnique();

            builder.Property(value => value.DateAndTime).HasColumnType("datetime");
        }
    }
}
