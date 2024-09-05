﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Zarani.Infrastructure.Context;

#nullable disable

namespace Zarani.Infrastructure.Migrations
{
    [DbContext(typeof(ZaraniDbContext))]
    partial class ZaraniDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Zarani.Infrastructure.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Zarani.Infrastructure.Models.ContentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Date1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Date2")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Date3")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Detail1")
                        .HasColumnType("text");

                    b.Property<string>("Detail2")
                        .HasColumnType("text");

                    b.Property<string>("Detail3")
                        .HasColumnType("text");

                    b.Property<string>("Field1")
                        .HasColumnType("text");

                    b.Property<string>("Field2")
                        .HasColumnType("text");

                    b.Property<string>("Field3")
                        .HasColumnType("text");

                    b.Property<string>("File1")
                        .HasColumnType("text");

                    b.Property<string>("File1AltText")
                        .HasColumnType("text");

                    b.Property<string>("File2")
                        .HasColumnType("text");

                    b.Property<string>("File2AltText")
                        .HasColumnType("text");

                    b.Property<string>("File3")
                        .HasColumnType("text");

                    b.Property<string>("File3AltText")
                        .HasColumnType("text");

                    b.Property<int?>("HeaderId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Num1")
                        .HasColumnType("integer");

                    b.Property<int?>("Num2")
                        .HasColumnType("integer");

                    b.Property<string>("OgImagePath")
                        .HasColumnType("text");

                    b.Property<int?>("Order")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeoAbstract")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("text");

                    b.Property<byte?>("Stat1")
                        .HasColumnType("smallint");

                    b.Property<byte?>("Stat2")
                        .HasColumnType("smallint");

                    b.Property<string>("Title1")
                        .HasColumnType("text");

                    b.Property<string>("Title2")
                        .HasColumnType("text");

                    b.Property<string>("Title3")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("ParentId");

                    b.ToTable("Contents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Tüm Kategoriler",
                            Permalink = ""
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Tv Koltuğu",
                            ParentId = 1,
                            Permalink = "tv-koltugu"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Baba Koltuğu",
                            ParentId = 1,
                            Permalink = "baba-koltugu"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Hasta Koltuğu",
                            ParentId = 1,
                            Permalink = "hasta-koltugu"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Sinema Koltuğu",
                            ParentId = 1,
                            Permalink = "sinema-koltugu"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Üst Menü",
                            Permalink = ""
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Anasayfa",
                            ParentId = 6,
                            Permalink = ""
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Kargom Nerede",
                            ParentId = 6,
                            Permalink = "kargom-nerede"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Yardım",
                            ParentId = 6,
                            Permalink = "yardim"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Siparişlerim",
                            ParentId = 6,
                            Permalink = "siparislerim"
                        },
                        new
                        {
                            Id = 11,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Orta Menü",
                            Permalink = "iletisim"
                        },
                        new
                        {
                            Id = 12,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "İletisim",
                            ParentId = 11,
                            Permalink = "iletisim"
                        },
                        new
                        {
                            Id = 13,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Yeni Ürünler",
                            ParentId = 11,
                            Permalink = "yeni-urunler"
                        },
                        new
                        {
                            Id = 14,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Fırsat Ürünleri",
                            ParentId = 11,
                            Permalink = "firsat-urunleri"
                        },
                        new
                        {
                            Id = 15,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Orta Menü",
                            Permalink = ""
                        },
                        new
                        {
                            Id = 16,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "İletisim",
                            ParentId = 15,
                            Permalink = "iletisim"
                        },
                        new
                        {
                            Id = 17,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Yeni Ürünler",
                            ParentId = 15,
                            Permalink = "yeni-urunler"
                        },
                        new
                        {
                            Id = 18,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Fırsat Ürünleri",
                            ParentId = 15,
                            Permalink = "firsat-urunleri"
                        },
                        new
                        {
                            Id = 19,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Kurumsal",
                            Permalink = ""
                        },
                        new
                        {
                            Id = 20,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Güvenli Alışveriş",
                            ParentId = 19,
                            Permalink = "iletisim"
                        },
                        new
                        {
                            Id = 21,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Hakkımızda",
                            ParentId = 19,
                            Permalink = "yeni-urunler"
                        },
                        new
                        {
                            Id = 22,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDeleted = false,
                            ModuleId = 1,
                            Name = "Bize Ulaşın",
                            ParentId = 19,
                            Permalink = "firsat-urunleri"
                        });
                });

            modelBuilder.Entity("Zarani.Infrastructure.Models.ModuleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Menu"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Brand"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Campaign"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Comment"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Content"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Faq"
                        },
                        new
                        {
                            Id = 7,
                            Name = "FaqCategory"
                        },
                        new
                        {
                            Id = 8,
                            Name = "LandingPage"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Model"
                        },
                        new
                        {
                            Id = 10,
                            Name = "ModelGallery"
                        },
                        new
                        {
                            Id = 11,
                            Name = "News"
                        },
                        new
                        {
                            Id = 12,
                            Name = "NewsGallery"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Slider"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Product"
                        });
                });

            modelBuilder.Entity("Zarani.Infrastructure.Models.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Zarani.Infrastructure.Models.SliderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("MobileImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("RedirectUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("WebImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
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
                    b.HasOne("Zarani.Infrastructure.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Zarani.Infrastructure.Models.ApplicationUser", null)
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

                    b.HasOne("Zarani.Infrastructure.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Zarani.Infrastructure.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zarani.Infrastructure.Models.ContentEntity", b =>
                {
                    b.HasOne("Zarani.Infrastructure.Models.ContentEntity", "Header")
                        .WithMany()
                        .HasForeignKey("HeaderId");

                    b.HasOne("Zarani.Infrastructure.Models.ModuleEntity", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zarani.Infrastructure.Models.ContentEntity", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Header");

                    b.Navigation("Module");

                    b.Navigation("Parent");
                });
#pragma warning restore 612, 618
        }
    }
}
