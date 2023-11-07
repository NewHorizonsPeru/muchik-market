using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes.pgsql
{
    public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("order_detail");

            builder.HasKey(e => new { e.OrderId, e.ProductId });

            builder.Property(e => e.ProductId)
                .HasColumnType("varchar(250)")
                .HasColumnName("product_id");

            builder.Property(e => e.OrderId)
                .HasColumnType("varchar(250)")
                .HasColumnName("order_id");

            builder.Property(e => e.Quantity)
                .HasColumnType("smallint")
                .HasColumnName("quantity");

            builder.Property(e => e.Price)
                .HasColumnType("decimal")
                .HasColumnName("price");

            builder.Property(e => e.Total)
                .HasColumnType("decimal")
                .HasColumnName("total");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_orderdetail");
        }
    }
}
