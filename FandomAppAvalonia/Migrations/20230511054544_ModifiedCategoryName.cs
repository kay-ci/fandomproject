using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomAppSpace.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category_name",
                table: "CATEGORIES",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CATEGORIES",
                newName: "Category_name");
        }
    }
}
