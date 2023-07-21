using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelNet.Domain.Entities.ClienteContext;

namespace TravelNet.Data.Mapping.ClienteContext
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasIndex(p => p.Passaporte)
                .IsUnique();

            builder.Property(p => p.Passaporte)
              .IsRequired()
              .HasMaxLength(7);

        }
    }


}
