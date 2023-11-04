using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes.pgsql
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(e => e.Id)
                .HasColumnType("varchar(250)")
                .HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Correlative)
                .HasColumnType("varchar(25)")
                .HasColumnName("correlative");

            builder.Property(e => e.CustomerId)
                .HasColumnType("varchar(250)")
                .HasColumnName("customer_id");

            builder.Property(e => e.State)
                .HasColumnType("smallint")
                .HasColumnName("state");

            builder.Property(e => e.Total)
                .HasColumnType("decimal")
                .HasColumnName("total");

            builder.Property(e => e.CreatedAt)
               .HasColumnType("timestamp")
               .HasColumnName("created_at");

            builder.HasMany(e => e.OrderDetail);
        }
    }
}
