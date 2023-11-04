using Microsoft.EntityFrameworkCore;
using midis.muchik.market.domain.entities;
using midis.muchik.market.infrastructure.configurations.entityTypes.mysql;

namespace midis.muchik.market.infrastructure.context
{
    public partial class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
