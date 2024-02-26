


using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class TripsContext : DbContext
{
    public TripsContext()
    {
    }

    public TripsContext(DbContextOptions<TripsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripsType> TripsTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog=Trips; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.IdBooking).HasName("PK__booking__3A710F7F721B57BD");

            entity.ToTable("booking");

            entity.Property(e => e.IdBooking).HasColumnName("idBooking");
            entity.Property(e => e.Datebooking)
                .HasColumnType("date")
                .HasColumnName("datebooking");
            entity.Property(e => e.IdTrip).HasColumnName("idTrip");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Places).HasColumnName("places");
            entity.Property(e => e.TimeBooking).HasColumnName("timeBooking");

            entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdTrip)
                .HasConstraintName("FK__booking__idTrip__5165187F");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__booking__idUser__5070F446");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip).HasName("PK__trips__B90DB49C93612F3D");

            entity.ToTable("trips");

            entity.Property(e => e.IdTrip).HasColumnName("idTrip");
            entity.Property(e => e.DateTrip)
                .HasColumnType("date")
                .HasColumnName("dateTrip");
            entity.Property(e => e.DestinationTrip)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("destinationTrip");
            entity.Property(e => e.DurationTrip).HasColumnName("durationTrip");
            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.Image).HasColumnType("text");
            entity.Property(e => e.LeavingTime).HasColumnName("leavingTime");
            entity.Property(e => e.PlacesAvailable).HasColumnName("placesAvailable");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("FK__trips__idType__48CFD27E");
        });

        modelBuilder.Entity<TripsType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK__tripsTyp__4BB98BC673666346");

            entity.ToTable("tripsTypes");

            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.NameType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__users__3717C9829CA5A43C");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserFirstAid).HasColumnName("userFirstAid");
            entity.Property(e => e.UserFirstName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("userFirstName");
            entity.Property(e => e.UserLastName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("userLastName");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userPhone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

