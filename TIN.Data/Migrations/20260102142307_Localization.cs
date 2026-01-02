using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIN.Data.Migrations
{
    /// <inheritdoc />
    public partial class Localization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Specs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Language = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => new { x.ProductId, x.Language });
                    table.ForeignKey(
                        name: "FK_ProductDescription_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecNames",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Language = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecNames", x => new { x.Name, x.Language });
                    table.ForeignKey(
                        name: "FK_SpecNames_Specs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecNames_SpecId",
                table: "SpecNames",
                column: "SpecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDescription");

            migrationBuilder.DropTable(
                name: "SpecNames");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Specs",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "TEXT",
                maxLength: 4000,
                nullable: true);
        }
    }
}
