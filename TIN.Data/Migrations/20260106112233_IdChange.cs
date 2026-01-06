using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIN.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecNames",
                table: "SpecNames");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SpecNames",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecNames",
                table: "SpecNames",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecNames",
                table: "SpecNames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SpecNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecNames",
                table: "SpecNames",
                columns: new[] { "Name", "Language" });
        }
    }
}
