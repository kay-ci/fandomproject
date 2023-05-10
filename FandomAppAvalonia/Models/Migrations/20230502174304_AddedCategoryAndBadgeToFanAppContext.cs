using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryAndBadgeToFanAppContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badge_FandomProfiles_ProfileId",
                table: "Badge");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_FandomEvents_EventId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_FandomProfiles_ProfileId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badge",
                table: "Badge");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "FandomCategories");

            migrationBuilder.RenameTable(
                name: "Badge",
                newName: "FandomBadges");

            migrationBuilder.RenameColumn(
                name: "cat_name",
                table: "FandomCategories",
                newName: "Category_name");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ProfileId",
                table: "FandomCategories",
                newName: "IX_FandomCategories_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_EventId",
                table: "FandomCategories",
                newName: "IX_FandomCategories_EventId");

            migrationBuilder.RenameColumn(
                name: "bad_name",
                table: "FandomBadges",
                newName: "badgeName");

            migrationBuilder.RenameIndex(
                name: "IX_Badge_ProfileId",
                table: "FandomBadges",
                newName: "IX_FandomBadges_ProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "Pronouns",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "FandomEvents",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "FandomEvents",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomCategories",
                table: "FandomCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomBadges",
                table: "FandomBadges",
                column: "BadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomBadges_FandomProfiles_ProfileId",
                table: "FandomBadges",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomCategories_FandomEvents_EventId",
                table: "FandomCategories",
                column: "EventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomCategories_FandomProfiles_ProfileId",
                table: "FandomCategories",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FandomBadges_FandomProfiles_ProfileId",
                table: "FandomBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomCategories_FandomEvents_EventId",
                table: "FandomCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomCategories_FandomProfiles_ProfileId",
                table: "FandomCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomCategories",
                table: "FandomCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomBadges",
                table: "FandomBadges");

            migrationBuilder.RenameTable(
                name: "FandomCategories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "FandomBadges",
                newName: "Badge");

            migrationBuilder.RenameColumn(
                name: "Category_name",
                table: "Category",
                newName: "cat_name");

            migrationBuilder.RenameIndex(
                name: "IX_FandomCategories_ProfileId",
                table: "Category",
                newName: "IX_Category_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_FandomCategories_EventId",
                table: "Category",
                newName: "IX_Category_EventId");

            migrationBuilder.RenameColumn(
                name: "badgeName",
                table: "Badge",
                newName: "bad_name");

            migrationBuilder.RenameIndex(
                name: "IX_FandomBadges_ProfileId",
                table: "Badge",
                newName: "IX_Badge_ProfileId");

            migrationBuilder.AlterColumn<string>(
                name: "Pronouns",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "FandomProfiles",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "FandomEvents",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "FandomEvents",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badge",
                table: "Badge",
                column: "BadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badge_FandomProfiles_ProfileId",
                table: "Badge",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_FandomEvents_EventId",
                table: "Category",
                column: "EventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_FandomProfiles_ProfileId",
                table: "Category",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");
        }
    }
}
