﻿// <auto-generated />
using System;
using BGCRestaurants.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BGCRestaurants.Api.Migrations
{
    [DbContext(typeof(BgcRestaurantsDbContext))]
    partial class BgcRestaurantsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("BGCRestaurants.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Valid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantName");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 3,
                            RestaurantName = "ABC",
                            Time = "17:00 PM",
                            UserName = "aaa@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 4,
                            RestaurantName = "ABC",
                            Time = "17:00 PM",
                            UserName = "bbb@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 4,
                            RestaurantName = "ABC",
                            Time = "17:00 PM",
                            UserName = "ccc@example.com",
                            Valid = false
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 2,
                            RestaurantName = "ABC",
                            Time = "18:00 PM",
                            UserName = "ddd@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 2,
                            RestaurantName = "ABC",
                            Time = "18:00 PM",
                            UserName = "eee@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 2,
                            RestaurantName = "ABC",
                            Time = "18:00 PM",
                            UserName = "fff@example.com",
                            Valid = false
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2020, 7, 1, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 1,
                            RestaurantName = "ABC",
                            Time = "19:00 PM",
                            UserName = "ggg@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 6,
                            RestaurantName = "DEF",
                            Time = "18:00 PM",
                            UserName = "hhh@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 7,
                            RestaurantName = "DEF",
                            Time = "18:00 PM",
                            UserName = "iii@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 10,
                            Date = new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 8,
                            RestaurantName = "DEF",
                            Time = "18:00 PM",
                            UserName = "jjj@example.com",
                            Valid = false
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateTime(2020, 7, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 3,
                            RestaurantName = "GHI",
                            Time = "16:00 PM",
                            UserName = "kkk@example.com",
                            Valid = false
                        },
                        new
                        {
                            Id = 12,
                            Date = new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 3,
                            RestaurantName = "GHI",
                            Time = "17:00 PM",
                            UserName = "lll@example.com",
                            Valid = true
                        },
                        new
                        {
                            Id = 13,
                            Date = new DateTime(2020, 7, 1, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfPeople = 3,
                            RestaurantName = "GHI",
                            Time = "22:00 PM",
                            UserName = "mmm@example.com",
                            Valid = false
                        });
                });

            modelBuilder.Entity("BGCRestaurants.Entities.Restaurant", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ClosingTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("LargeTables")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediumTables")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("OpeningTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("SmallTables")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Name = "ABC",
                            ClosingTime = new TimeSpan(0, 23, 0, 0, 0),
                            LargeTables = 1,
                            MediumTables = 2,
                            OpeningTime = new TimeSpan(0, 15, 0, 0, 0),
                            SmallTables = 2
                        },
                        new
                        {
                            Name = "DEF",
                            ClosingTime = new TimeSpan(0, 22, 0, 0, 0),
                            LargeTables = 2,
                            MediumTables = 3,
                            OpeningTime = new TimeSpan(0, 16, 0, 0, 0),
                            SmallTables = 2
                        },
                        new
                        {
                            Name = "GHI",
                            ClosingTime = new TimeSpan(0, 21, 0, 0, 0),
                            LargeTables = 1,
                            MediumTables = 2,
                            OpeningTime = new TimeSpan(0, 17, 0, 0, 0),
                            SmallTables = 1
                        });
                });

            modelBuilder.Entity("BGCRestaurants.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BGCRestaurants.Entities.Reservation", b =>
                {
                    b.HasOne("BGCRestaurants.Entities.Restaurant", null)
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantName");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BGCRestaurants.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BGCRestaurants.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BGCRestaurants.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BGCRestaurants.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BGCRestaurants.Entities.Restaurant", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
