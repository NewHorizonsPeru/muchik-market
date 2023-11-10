using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using midis.muchik.market.domain.entities;

namespace midis.muchik.market.infrastructure.configurations.entityTypes.mssql
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.Property(e => e.Id)
                .HasColumnType("varchar(250)")
                .HasColumnName("id");

            builder.HasKey(e => e.Id);          

            builder.Property(e => e.FirstName)
                .HasColumnType("varchar(250)")
                .HasColumnName("first_name");

            builder.Property(e => e.LastName)
               .HasColumnType("varchar(250)")
               .HasColumnName("last_name");

            builder.Property(e => e.DocumentNumber)
                .HasColumnType("varchar(12)")
                .HasColumnName("document_number");

            builder.Property(e => e.PhoneNumber)
                .HasColumnType("varchar(12)")
                .HasColumnName("phone_number");

            builder.Property(e => e.UserId)
                .HasColumnType("varchar(250)")
                .HasColumnName("user_id");

            builder.Property(e => e.BornedAt)
              .HasColumnType("datetime")
              .HasColumnName("borned_at");

            builder.Property(e => e.CreatedAt)
               .HasColumnType("datetime")
               .HasColumnName("created_at");

            builder.Property(e => e.IsActive)
               .HasColumnType("bit")
               .HasColumnName("is_active");
        }
    }
}
