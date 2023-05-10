using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "badgeName",
                table: "FandomBadges",
                newName: "BadgeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BadgeName",
                table: "FandomBadges",
                newName: "badgeName");
        }
    }
}
