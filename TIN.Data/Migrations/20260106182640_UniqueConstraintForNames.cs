using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TIN.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SpecNames_Language_Name_SpecId",
                table: "SpecNames",
                columns: new[] { "Language", "Name", "SpecId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpecNames_Language_Name_SpecId",
                table: "SpecNames");
        }
    }
}
