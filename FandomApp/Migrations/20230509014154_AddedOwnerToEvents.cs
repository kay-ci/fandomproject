using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedOwnerToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_FandomEvents_EventsEventId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "EventsEventId",
                table: "EventUser",
                newName: "EventsAttendingEventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_EventsEventId",
                table: "EventUser",
                newName: "IX_EventUser_EventsAttendingEventId");

            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "FandomEvents",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FandomEvents_userID",
                table: "FandomEvents",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_FandomEvents_EventsAttendingEventId",
                table: "EventUser",
                column: "EventsAttendingEventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomEvents_FandomUsers_userID",
                table: "FandomEvents",
                column: "userID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_FandomEvents_EventsAttendingEventId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomEvents_FandomUsers_userID",
                table: "FandomEvents");

            migrationBuilder.DropIndex(
                name: "IX_FandomEvents_userID",
                table: "FandomEvents");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "FandomEvents");

            migrationBuilder.RenameColumn(
                name: "EventsAttendingEventId",
                table: "EventUser",
                newName: "EventsEventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_EventsAttendingEventId",
                table: "EventUser",
                newName: "IX_EventUser_EventsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_FandomEvents_EventsEventId",
                table: "EventUser",
                column: "EventsEventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
