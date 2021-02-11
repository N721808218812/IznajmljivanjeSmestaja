﻿// <auto-generated />
using System;
using IznajmljivanjeSmestaja.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IznajmljivanjeSmestaja.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20210211143416_addedIdAcStaging")]
    partial class addedIdAcStaging
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AccomadationGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdAccomodation")
                        .HasColumnName("idAccomodation");

                    b.Property<int?>("IdAccomodationStaging");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnName("url")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdAccomodation");

                    b.ToTable("AccomadationGallery");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.Accomodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasMaxLength(150);

                    b.Property<string>("Amenities")
                        .HasColumnName("amenities")
                        .HasMaxLength(100);

                    b.Property<string>("Checkin")
                        .IsRequired()
                        .HasColumnName("checkin")
                        .HasMaxLength(50);

                    b.Property<string>("Checkout")
                        .IsRequired()
                        .HasColumnName("checkout")
                        .HasMaxLength(50);

                    b.Property<string>("CoverPhotoUrl")
                        .HasColumnName("coverPhotoUrl")
                        .HasMaxLength(200);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasMaxLength(1000);

                    b.Property<string>("Directions")
                        .HasColumnName("directions")
                        .HasMaxLength(100);

                    b.Property<int>("Guests")
                        .HasColumnName("guests");

                    b.Property<string>("IdUser")
                        .HasColumnName("idUser")
                        .HasMaxLength(450);

                    b.Property<int>("Rooms")
                        .HasColumnName("rooms");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(50);

                    b.Property<bool?>("Wifi")
                        .HasColumnName("wifi");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Accomodation");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AccomodationStaging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasMaxLength(150);

                    b.Property<string>("Amenities")
                        .HasColumnName("amenities")
                        .HasMaxLength(100);

                    b.Property<string>("Checkin")
                        .IsRequired()
                        .HasColumnName("checkin")
                        .HasMaxLength(50);

                    b.Property<string>("Checkout")
                        .IsRequired()
                        .HasColumnName("checkout")
                        .HasMaxLength(50);

                    b.Property<string>("CoverPhotoUrl")
                        .HasColumnName("coverPhotoUrl")
                        .HasMaxLength(200);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasMaxLength(1000);

                    b.Property<string>("Directions")
                        .HasColumnName("directions")
                        .HasMaxLength(100);

                    b.Property<int>("Guests")
                        .HasColumnName("guests");

                    b.Property<string>("IdUser")
                        .HasColumnName("idUser")
                        .HasMaxLength(450);

                    b.Property<int>("Rooms")
                        .HasColumnName("rooms");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(50);

                    b.Property<bool?>("Wifi")
                        .HasColumnName("wifi");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("AccomodationStaging");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCheckin")
                        .HasColumnName("dateCheckin")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateCheckout")
                        .HasColumnName("dateCheckout")
                        .HasColumnType("date");

                    b.Property<int>("IdAccomodation")
                        .HasColumnName("idAccomodation");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnName("idUser")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("IdAccomodation");

                    b.HasIndex("IdUser");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AccomadationGallery", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.Accomodation", "IdAccomodationNavigation")
                        .WithMany("AccomadationGallery")
                        .HasForeignKey("IdAccomodation")
                        .HasConstraintName("FK_AccomadationGallery_Accomodation");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.Accomodation", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "IdUserNavigation")
                        .WithMany("Accomodation")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_Accomodation_AspNetUsers");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AccomodationStaging", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "IdUserNavigation")
                        .WithMany("AccomodationStaging")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_AccomodationStaging_AspNetUsers");
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.AspNetUserTokens", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IznajmljivanjeSmestaja.Models.Reservation", b =>
                {
                    b.HasOne("IznajmljivanjeSmestaja.Models.Accomodation", "IdAccomodationNavigation")
                        .WithMany("Reservation")
                        .HasForeignKey("IdAccomodation")
                        .HasConstraintName("FK_Reservation_Accomodation1");

                    b.HasOne("IznajmljivanjeSmestaja.Models.AspNetUsers", "IdUserNavigation")
                        .WithMany("Reservation")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_Reservation_AspNetUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
