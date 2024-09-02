using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zarani.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContentModule20240827 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModuleId = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    HeaderId = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Contents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
