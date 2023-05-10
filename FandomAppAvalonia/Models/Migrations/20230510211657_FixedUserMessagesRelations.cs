using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserMessagesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FandomMessages_FandomUserMessages_UserMessageId",
                table: "FandomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomMessages_FandomUserMessages_UserMessageId1",
                table: "FandomMessages");

            migrationBuilder.DropTable(
                name: "FandomUserMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomMessages",
                table: "FandomMessages");

            migrationBuilder.DropIndex(
                name: "IX_FandomMessages_UserMessageId",
                table: "FandomMessages");

            migrationBuilder.DropIndex(
                name: "IX_FandomMessages_UserMessageId1",
                table: "FandomMessages");

            migrationBuilder.DropColumn(
                name: "UserMessageId",
                table: "FandomMessages");

            migrationBuilder.DropColumn(
                name: "UserMessageId1",
                table: "FandomMessages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FandomMessages",
                newName: "userID");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "FandomMessages",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "FandomMessages",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0)
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomMessages",
                table: "FandomMessages",
                column: "MessageId");

            migrationBuilder.CreateTable(
                name: "MessageUser",
                columns: table => new
                {
                    InboxMessageId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecipientsuserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUser", x => new { x.InboxMessageId, x.RecipientsuserID });
                    table.ForeignKey(
                        name: "FK_MessageUser_FandomMessages_InboxMessageId",
                        column: x => x.InboxMessageId,
                        principalTable: "FandomMessages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUser_FandomUsers_RecipientsuserID",
                        column: x => x.RecipientsuserID,
                        principalTable: "FandomUsers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FandomMessages_userID",
                table: "FandomMessages",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_RecipientsuserID",
                table: "MessageUser",
                column: "RecipientsuserID");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomMessages_FandomUsers_userID",
                table: "FandomMessages",
                column: "userID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FandomMessages_FandomUsers_userID",
                table: "FandomMessages");

            migrationBuilder.DropTable(
                name: "MessageUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomMessages",
                table: "FandomMessages");

            migrationBuilder.DropIndex(
                name: "IX_FandomMessages_userID",
                table: "FandomMessages");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "FandomMessages");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "FandomMessages",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FandomMessages",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "UserMessageId",
                table: "FandomMessages",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserMessageId1",
                table: "FandomMessages",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomMessages",
                table: "FandomMessages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FandomUserMessages",
                columns: table => new
                {
                    UserMessageId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomUserMessages", x => x.UserMessageId);
                    table.ForeignKey(
                        name: "FK_FandomUserMessages_FandomUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FandomUsers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FandomMessages_UserMessageId",
                table: "FandomMessages",
                column: "UserMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_FandomMessages_UserMessageId1",
                table: "FandomMessages",
                column: "UserMessageId1");

            migrationBuilder.CreateIndex(
                name: "IX_FandomUserMessages_UserId",
                table: "FandomUserMessages",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomMessages_FandomUserMessages_UserMessageId",
                table: "FandomMessages",
                column: "UserMessageId",
                principalTable: "FandomUserMessages",
                principalColumn: "UserMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomMessages_FandomUserMessages_UserMessageId1",
                table: "FandomMessages",
                column: "UserMessageId1",
                principalTable: "FandomUserMessages",
                principalColumn: "UserMessageId");
        }
    }
}
