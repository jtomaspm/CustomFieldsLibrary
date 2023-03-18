using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<ContainerType> ContainerTypes { get; set; }

    public virtual DbSet<Depot> Depots { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<EntityType> EntityTypes { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=192.168.1.113;Database=CustomFieldsExample;TrustServerCertificate=True;User=sa;Password=Cr0ssr0ads1!;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Container>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Containe__3214EC074D2E127E");

            entity.ToTable("Container");

            entity.Property(e => e.Code)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ContainerTypeId).HasColumnName("Container_Type_Id");
            entity.Property(e => e.OwenerId).HasColumnName("Owener_Id");

            entity.HasOne(d => d.ContainerType).WithMany(p => p.Containers)
                .HasForeignKey(d => d.ContainerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Container__Conta__2F10007B");

            entity.HasOne(d => d.Owener).WithMany(p => p.Containers)
                .HasForeignKey(d => d.OwenerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Container__Owene__2E1BDC42");
        });

        modelBuilder.Entity<ContainerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Containe__3214EC07E0E2C2EC");

            entity.ToTable("Container_Type");

            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Depot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Depot__3214EC075653684C");

            entity.ToTable("Depot");

            entity.Property(e => e.Location)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.OwenerId).HasColumnName("Owener_Id");

            entity.HasOne(d => d.Owener).WithMany(p => p.Depots)
                .HasForeignKey(d => d.OwenerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Depot__Owener_Id__29572725");
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entity__3214EC0789155CC1");

            entity.ToTable("Entity");

            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Entities)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Entity__Type__267ABA7A");
        });

        modelBuilder.Entity<EntityType>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__Entity_T__737584F7D1AA7E41");

            entity.ToTable("Entity_Type");

            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3214EC07F0AC927F");

            entity.ToTable("Operation");

            entity.Property(e => e.ContainerId).HasColumnName("Container_Id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DepotId).HasColumnName("Depot_Id");
            entity.Property(e => e.OperationType)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("Operation_Type");

            entity.HasOne(d => d.Container).WithMany(p => p.Operations)
                .HasForeignKey(d => d.ContainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__Conta__33D4B598");

            entity.HasOne(d => d.Depot).WithMany(p => p.Operations)
                .HasForeignKey(d => d.DepotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__Depot__35BCFE0A");

            entity.HasOne(d => d.OperationTypeNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.OperationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operation__Opera__34C8D9D1");
        });

        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__Operatio__737584F7E3233793");

            entity.ToTable("Operation_Type");

            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
