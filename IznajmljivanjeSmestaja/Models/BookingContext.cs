using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IznajmljivanjeSmestaja.Models
{
    public partial class BookingContext : DbContext
    {
        public BookingContext()
        {
        }

        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccomadationGallery> AccomadationGallery { get; set; }
        public virtual DbSet<Accomodation> Accomodation { get; set; }
        public virtual DbSet<AccomodationStaging> AccomodationStaging { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CCNFDCI\\SQLEXPRESS;Database=Booking;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AccomadationGallery>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAccomodation).HasColumnName("idAccomodation");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdAccomodationNavigation)
                    .WithMany(p => p.AccomadationGallery)
                    .HasForeignKey(d => d.IdAccomodation)
                    .HasConstraintName("FK_AccomadationGallery_Accomodation");
            });

            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(150);

                entity.Property(e => e.Amenities)
                    .HasColumnName("amenities")
                    .HasMaxLength(100);

                entity.Property(e => e.Checkin)
                    .IsRequired()
                    .HasColumnName("checkin")
                    .HasMaxLength(50);

                entity.Property(e => e.Checkout)
                    .IsRequired()
                    .HasColumnName("checkout")
                    .HasMaxLength(50);

                entity.Property(e => e.CoverPhotoUrl)
                    .HasColumnName("coverPhotoUrl")
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Directions)
                    .HasColumnName("directions")
                    .HasMaxLength(100);

                entity.Property(e => e.Guests).HasColumnName("guests");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(450);

                entity.Property(e => e.Rooms).HasColumnName("rooms");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Wifi).HasColumnName("wifi");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Accomodation)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Accomodation_AspNetUsers");
            });

            modelBuilder.Entity<AccomodationStaging>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(150);

                entity.Property(e => e.Amenities)
                    .HasColumnName("amenities")
                    .HasMaxLength(100);

                entity.Property(e => e.Checkin)
                    .IsRequired()
                    .HasColumnName("checkin")
                    .HasMaxLength(50);

                entity.Property(e => e.Checkout)
                    .IsRequired()
                    .HasColumnName("checkout")
                    .HasMaxLength(50);

                entity.Property(e => e.CoverPhotoUrl)
                    .HasColumnName("coverPhotoUrl")
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Directions)
                    .HasColumnName("directions")
                    .HasMaxLength(100);

                entity.Property(e => e.Guests).HasColumnName("guests");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(450);

                entity.Property(e => e.Rooms).HasColumnName("rooms");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Wifi).HasColumnName("wifi");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AccomodationStaging)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_AccomodationStaging_AspNetUsers");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCheckin)
                    .HasColumnName("dateCheckin")
                    .HasColumnType("date");

                entity.Property(e => e.DateCheckout)
                    .HasColumnName("dateCheckout")
                    .HasColumnType("date");

                entity.Property(e => e.IdAccomodation).HasColumnName("idAccomodation");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("idUser")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdAccomodationNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.IdAccomodation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Accomodation1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_AspNetUsers");
            });
        }
    }
}
