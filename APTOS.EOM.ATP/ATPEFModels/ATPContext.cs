using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APTOS.EOM.ATPService.ATPEFModels
{
    public partial class ATPContext : DbContext
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
                optionsBuilder.UseSqlServer("Server=sql.dev.eom.aptos.io;Database=ATP;User ID=RJeyapaul;PWD=;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AtpItem>(entity =>
            {
                entity.Property(e => e.AtpitemId).HasColumnName("ATPItemId");

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.LogisticsData).HasMaxLength(500);

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
                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.LogisticsData).HasMaxLength(500);

                entity.Property(e => e.SalesChannelData).HasMaxLength(500);

                entity.Property(e => e.TotalDeliveryCost).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<AtpTransactionNotes>(entity =>
            {
                entity.Property(e => e.Context).HasMaxLength(50);

                entity.Property(e => e.CreateDatetimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.NoteReferenceId).HasMaxLength(20);

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

                entity.Property(e => e.ItemDeliveryCost).HasColumnType("decimal(18, 2)");

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

                entity.Property(e => e.PickupLocaionExternalId).HasMaxLength(50);

                entity.Property(e => e.ShippingLocaionExternalId).HasMaxLength(50);

                entity.Property(e => e.UpdateDatetimeUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Atpitem)
                    .WithMany(p => p.ItemReservation)
                    .HasForeignKey(d => d.AtpitemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemReservation_ATPItem");

                entity.HasOne(d => d.ServiceStatus)
                    .WithMany(p => p.ItemReservation)
                    .HasForeignKey(d => d.ServiceStatusId)
                    .HasConstraintName("FK_ItemReservation_ATPStatus");
            });

            modelBuilder.Entity<ServiceConfiguration>(entity =>
            {
                entity.HasKey(e => e.ServiceConfigKey)
                    .HasName("PK_atpinfrastructure");

                entity.Property(e => e.ServiceConfigKey)
                    .HasColumnName("serviceConfigKey")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.ServiceConfigValue)
                    .IsRequired()
                    .HasColumnName("serviceConfigValue")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ServiceStatus>(entity =>
            {
                entity.HasIndex(e => e.Status)
                    .HasName("status_atpstatusname_key")
                    .IsUnique();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StatusDescription).HasMaxLength(100);
            });
        }
    }
}
