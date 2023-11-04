using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes.mysql
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");

            builder.Property(e => e.Id)
                .HasColumnType("varchar(250)")
                .HasColumnName("id");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Name)
                .HasColumnType("varchar(150)")
                .HasColumnName("name");

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
        }
    }
}
