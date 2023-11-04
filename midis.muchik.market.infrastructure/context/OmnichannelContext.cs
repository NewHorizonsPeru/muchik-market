using Microsoft.EntityFrameworkCore;
using midis.muchik.market.domain.entities;
using midis.muchik.market.infrastructure.configurations.entityTypes.mysql;
using midis.muchik.market.infrastructure.configurations.entityTypes.pgsql;

namespace midis.muchik.market.infrastructure.context
{
    public partial class OmnichannelContext : DbContext
    {
        public OmnichannelContext(DbContextOptions<OmnichannelContext> options) : base(options) { }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
