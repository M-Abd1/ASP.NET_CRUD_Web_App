using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bliss_Travels___Tours.Models;

public partial class TouristTravelsContext : DbContext
{
    public TouristTravelsContext()
    {
    }

    public TouristTravelsContext(DbContextOptions<TouristTravelsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TourManager> TourManagers { get; set; }

    public virtual DbSet<Tourist> Tourists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TourManager>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PK__TourMana__519D1D63B5E7C635");

            entity.ToTable("TourManager");

            entity.Property(e => e.TourId).HasColumnName("tourId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartureDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("departureDate");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Destination)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("destination");
            entity.Property(e => e.ReturnDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("returnDate");
            entity.Property(e => e.StartingPosition)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("startingPosition");
        });

        modelBuilder.Entity<Tourist>(entity =>
        {
            entity.HasKey(e => e.TouristId).HasName("PK__tmp_ms_x__BBB2E8B7C0549885");

            entity.ToTable("Tourist");

            entity.Property(e => e.TouristId)
                .HasMaxLength(50)
                .HasColumnName("touristId");
            entity.Property(e => e.Address)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.TourId).HasColumnName("tourId");

            entity.HasOne(d => d.Tour).WithMany(p => p.Tourists)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tourist__tourId__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
