using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");

            builder.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
        }
    }
}
