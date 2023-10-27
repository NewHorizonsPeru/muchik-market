using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            
            builder.Property(e => e.Id)
                .HasColumnType("varchar(250)")
                .HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.BrandId).HasColumnName("brand_id");

            builder.Property(e => e.CategoryId).HasColumnName("category_id");

            builder.Property(e => e.Name)
                .HasColumnType("varchar(250)")
                .HasColumnName("name");

            builder.Property(e => e.Sku)
                .HasColumnType("varchar(12)")
                .HasColumnName("sku");

            builder.Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("price");

            builder.Property(e => e.Description)
                .HasColumnType("varchar(1000)")
                .HasColumnName("description");

            builder.Property(e => e.Score)
                .HasColumnName("score");

            builder.Property(e => e.Stock)
                .HasColumnName("stock");

            builder.Property(e => e.CreatedAt)
               .HasColumnType("datetime")
               .HasColumnName("created_at");

            builder.HasOne(d => d.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_brand");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_category");
        }
    }
}
