using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zarani.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModuleId = table.Column<int>(type: "integer", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    HeaderId = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Permalink = table.Column<string>(type: "text", nullable: false),
                    Title1 = table.Column<string>(type: "text", nullable: true),
                    Title2 = table.Column<string>(type: "text", nullable: true),
                    Title3 = table.Column<string>(type: "text", nullable: true),
                    Field1 = table.Column<string>(type: "text", nullable: true),
                    Field2 = table.Column<string>(type: "text", nullable: true),
                    Field3 = table.Column<string>(type: "text", nullable: true),
                    Date1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Date2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Date3 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Detail1 = table.Column<string>(type: "text", nullable: true),
                    Detail2 = table.Column<string>(type: "text", nullable: true),
                    Detail3 = table.Column<string>(type: "text", nullable: true),
                    Stat1 = table.Column<byte>(type: "smallint", nullable: true),
                    Stat2 = table.Column<byte>(type: "smallint", nullable: true),
                    Num1 = table.Column<int>(type: "integer", nullable: true),
                    Num2 = table.Column<int>(type: "integer", nullable: true),
                    File1 = table.Column<string>(type: "text", nullable: true),
                    File2 = table.Column<string>(type: "text", nullable: true),
                    File3 = table.Column<string>(type: "text", nullable: true),
                    File1AltText = table.Column<string>(type: "text", nullable: true),
                    File2AltText = table.Column<string>(type: "text", nullable: true),
                    File3AltText = table.Column<string>(type: "text", nullable: true),
                    SeoTitle = table.Column<string>(type: "text", nullable: true),
                    SeoAbstract = table.Column<string>(type: "text", nullable: true),
                    SeoKeywords = table.Column<string>(type: "text", nullable: true),
                    SeoDescription = table.Column<string>(type: "text", nullable: true),
                    OgImagePath = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Contents_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contents_Contents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contents_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Menu" },
                    { 2, "Brand" },
                    { 3, "Campaign" },
                    { 4, "Comment" },
                    { 5, "Content" },
                    { 6, "Faq" },
                    { 7, "FaqCategory" },
                    { 8, "LandingPage" },
                    { 9, "Model" },
                    { 10, "ModelGallery" },
                    { 11, "News" },
                    { 12, "NewsGallery" },
                    { 13, "Slider" },
                    { 14, "Product" }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "Created", "Date1", "Date2", "Date3", "Detail1", "Detail2", "Detail3", "Field1", "Field2", "Field3", "File1", "File1AltText", "File2", "File2AltText", "File3", "File3AltText", "HeaderId", "IsActive", "IsDeleted", "ModuleId", "Name", "Num1", "Num2", "OgImagePath", "Order", "ParentId", "Permalink", "SeoAbstract", "SeoDescription", "SeoKeywords", "SeoTitle", "Stat1", "Stat2", "Title1", "Title2", "Title3" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Tüm Kategoriler", null, null, null, null, null, "", null, null, null, null, null, null, null, null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Üst Menü", null, null, null, null, null, "", null, null, null, null, null, null, null, null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Orta Menü", null, null, null, null, null, "iletisim", null, null, null, null, null, null, null, null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Orta Menü", null, null, null, null, null, "", null, null, null, null, null, null, null, null, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Kurumsal", null, null, null, null, null, "", null, null, null, null, null, null, null, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Tv Koltuğu", null, null, null, null, 1, "tv-koltugu", null, null, null, null, null, null, null, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Baba Koltuğu", null, null, null, null, 1, "baba-koltugu", null, null, null, null, null, null, null, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Hasta Koltuğu", null, null, null, null, 1, "hasta-koltugu", null, null, null, null, null, null, null, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Sinema Koltuğu", null, null, null, null, 1, "sinema-koltugu", null, null, null, null, null, null, null, null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Anasayfa", null, null, null, null, 6, "", null, null, null, null, null, null, null, null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Kargom Nerede", null, null, null, null, 6, "kargom-nerede", null, null, null, null, null, null, null, null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Yardım", null, null, null, null, 6, "yardim", null, null, null, null, null, null, null, null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Siparişlerim", null, null, null, null, 6, "siparislerim", null, null, null, null, null, null, null, null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "İletisim", null, null, null, null, 11, "iletisim", null, null, null, null, null, null, null, null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Yeni Ürünler", null, null, null, null, 11, "yeni-urunler", null, null, null, null, null, null, null, null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Fırsat Ürünleri", null, null, null, null, 11, "firsat-urunleri", null, null, null, null, null, null, null, null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "İletisim", null, null, null, null, 15, "iletisim", null, null, null, null, null, null, null, null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Yeni Ürünler", null, null, null, null, 15, "yeni-urunler", null, null, null, null, null, null, null, null, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Fırsat Ürünleri", null, null, null, null, 15, "firsat-urunleri", null, null, null, null, null, null, null, null, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Güvenli Alışveriş", null, null, null, null, 19, "iletisim", null, null, null, null, null, null, null, null, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Hakkımızda", null, null, null, null, 19, "yeni-urunler", null, null, null, null, null, null, null, null, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, false, 1, "Bize Ulaşın", null, null, null, null, 19, "firsat-urunleri", null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_HeaderId",
                table: "Contents",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ModuleId",
                table: "Contents",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ParentId",
                table: "Contents",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
