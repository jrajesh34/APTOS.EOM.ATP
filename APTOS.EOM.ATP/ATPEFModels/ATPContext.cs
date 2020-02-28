using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public class ATPContext : DbContext
    {
        public ATPContext()
        {
        }

        public ATPContext(DbContextOptions<ATPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AtpItem> AtpItem { get; set; }
        public virtual DbSet<AtpTransaction> AtpTransaction { get; set; }
        public virtual DbSet<AtpTransactionNotes> AtpTransactionNotes { get; set; }
        public virtual DbSet<ItemDelivery> ItemDelivery { get; set; }
        public virtual DbSet<ItemReservation> ItemReservation { get; set; }
        public virtual DbSet<ServiceConfiguration> ServiceConfiguration { get; set; }
        public virtual DbSet<ServiceStatus> ServiceStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sql.dev.eom.aptos.io;Database=ATP;User ID=RJeyapaul;PWD=Zensarin@1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AtpItem>(entity =>
            {
                entity.Property(e => e.AtpitemId).HasColumnName("ATPItemId");

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Isnonmerchflag).HasColumnName("isnonmerchflag");

                entity.Property(e => e.Iteminternalid).HasColumnName("iteminternalid");

                entity.Property(e => e.LogisticsData).HasMaxLength(500);

                entity.Property(e => e.Productexternalid).HasColumnName("productexternalid");

                entity.Property(e => e.Productinternalid).HasColumnName("productinternalid");

                entity.Property(e => e.SalesChannelData).HasMaxLength(500);

                entity.Property(e => e.Shippingmethod)
                    .HasColumnName("shippingmethod")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");

                entity.HasOne(d => d.AtpTransaction)
                    .WithMany(p => p.AtpItem)
                    .HasForeignKey(d => d.AtpTransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATPItem_AtpTransaction");
            });

            modelBuilder.Entity<AtpTransaction>(entity =>
            {
                entity.Property(e => e.Cartexternalid).HasColumnName("cartexternalid");

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.LogisticsData).HasColumnType("text");

                entity.Property(e => e.Orderinternalid).HasColumnName("orderinternalid");

                entity.Property(e => e.SalesChannelData).HasColumnType("text");

                entity.Property(e => e.Totaldeliverycost)
                    .HasColumnName("totaldeliverycost")
                    .HasColumnType("numeric(19, 4)");

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<AtpTransactionNotes>(entity =>
            {
                entity.Property(e => e.AtptransContext)
                    .HasColumnName("atptransContext")
                    .HasMaxLength(50);

                entity.Property(e => e.AtptransNote)
                    .HasColumnName("atptransNote")
                    .HasColumnType("text");

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");

                entity.HasOne(d => d.AtpTransaction)
                    .WithMany(p => p.AtpTransactionNotes)
                    .HasForeignKey(d => d.AtpTransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtpTransactionNotes_AtpTransaction");
            });

            modelBuilder.Entity<ItemDelivery>(entity =>
            {
                entity.Property(e => e.AtpitemId).HasColumnName("ATPItemId");

                entity.Property(e => e.Carrier).HasMaxLength(50);

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.DcDeliveryDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryTimeWindow).HasMaxLength(20);

                entity.Property(e => e.ItemDeliveryCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PickDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.ServiceLevel).HasMaxLength(50);

                entity.Property(e => e.ShippingDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Atpitem)
                    .WithMany(p => p.ItemDelivery)
                    .HasForeignKey(d => d.AtpitemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemDelivery_ATPItem");

                entity.HasOne(d => d.ServiceStatus)
                    .WithMany(p => p.ItemDelivery)
                    .HasForeignKey(d => d.ServiceStatusId)
                    .HasConstraintName("FK_ItemDelivery_ATPStatus");
            });

            modelBuilder.Entity<ItemReservation>(entity =>
            {
                entity.Property(e => e.AtpitemId).HasColumnName("ATPItemId");

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.PickupLocationExternalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShippingLocationExternalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Atpitem)
                    .WithMany(p => p.ItemReservation)
                    .HasForeignKey(d => d.AtpitemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemReservation_ATPItem");

                entity.HasOne(d => d.ServiceStatus)
                    .WithMany(p => p.ItemReservation)
                    .HasForeignKey(d => d.ServiceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemReservation_ATPStatus");
            });

            modelBuilder.Entity<ServiceConfiguration>(entity =>
            {
                entity.HasKey(e => e.SettingKey)
                    .HasName("PK_atpinfrastructure");

                entity.Property(e => e.SettingKey)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.SettingComments).HasMaxLength(500);

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ServiceStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("status_pkey");

                entity.HasIndex(e => e.Name)
                    .HasName("status_atpstatusname_key")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
