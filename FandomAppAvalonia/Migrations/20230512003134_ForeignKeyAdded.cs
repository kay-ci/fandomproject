using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomAppSpace.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MESSAGES_USERS_SenderUserID",
                table: "MESSAGES");

            migrationBuilder.RenameColumn(
                name: "SenderUserID",
                table: "MESSAGES",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_MESSAGES_SenderUserID",
                table: "MESSAGES",
                newName: "IX_MESSAGES_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MESSAGES_USERS_UserID",
                table: "MESSAGES",
                column: "UserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MESSAGES_USERS_UserID",
                table: "MESSAGES");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "MESSAGES",
                newName: "SenderUserID");

            migrationBuilder.RenameIndex(
                name: "IX_MESSAGES_UserID",
                table: "MESSAGES",
                newName: "IX_MESSAGES_SenderUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MESSAGES_USERS_SenderUserID",
                table: "MESSAGES",
                column: "SenderUserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
