using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes.mysql
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(e => e.Id)
                .HasColumnType("varchar(250)")
                .HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                .HasColumnType("varchar(250)")
                .HasColumnName("email");

            builder.Property(e => e.Password)
                .HasColumnType("varchar(250)")
                .HasColumnName("password");

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.RoleId).HasColumnName("role_id");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role");
        }
    }
}
