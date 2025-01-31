using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backwards.Models;

public partial class YourDbContext : DbContext
{
    public YourDbContext()
    {
    }

    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EntityAttributeValue> EntityAttributeValues { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventItem> EventItems { get; set; }

    public virtual DbSet<EventUser> EventUsers { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PotLuck; User Id=sa; Password=password0!; Encrypt=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityAttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EntityAt__3213E83FED11FC8B");

            entity.ToTable("EntityAttributeValue");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateModified).HasColumnName("dateModified");
            entity.Property(e => e.EntityAttribute).HasMaxLength(450);
            entity.Property(e => e.EntityName).HasMaxLength(450);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3213E83FBB6BC4DF");

            entity.ToTable("Event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateModified).HasColumnName("dateModified");
            entity.Property(e => e.Description).HasMaxLength(450);
            entity.Property(e => e.Location).HasMaxLength(450);
        });

        modelBuilder.Entity<EventItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventIte__3213E83F936AE95A");

            entity.ToTable("EventItem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateModified).HasColumnName("dateModified");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventUserId).HasColumnName("EventUserID");
            entity.Property(e => e.UnitOfMeasure).HasMaxLength(50);

            entity.HasOne(d => d.Event).WithMany(p => p.EventItems)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_EventItem_Event");
        });

        modelBuilder.Entity<EventUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventUse__3213E83FA211AB56");

            entity.ToTable("EventUser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AspNetUserId)
                .HasMaxLength(450)
                .HasColumnName("AspNetUserID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateModified).HasColumnName("dateModified");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventUserId).HasColumnName("EventUserID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventUsers)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_EventUser_Event");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3213E83F8C1CFE60");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateModified).HasColumnName("dateModified");
            entity.Property(e => e.EventItemId).HasColumnName("EventItemID");
            entity.Property(e => e.EventUserId).HasColumnName("EventUserID");
            entity.Property(e => e.QtyContribution).HasColumnName("qtyContribution");

            entity.HasOne(d => d.EventItem).WithMany(p => p.Participants)
                .HasForeignKey(d => d.EventItemId)
                .HasConstraintName("FK_Participant_EventItem");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
