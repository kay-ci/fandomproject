using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedFandomsToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FandomCategories_FandomEvents_EventId",
                table: "FandomCategories");

            migrationBuilder.DropIndex(
                name: "IX_FandomCategories_EventId",
                table: "FandomCategories");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "FandomCategories");

            migrationBuilder.CreateTable(
                name: "CategoryEvent",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    eventsEventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEvent", x => new { x.CategoriesCategoryId, x.eventsEventId });
                    table.ForeignKey(
                        name: "FK_CategoryEvent_FandomCategories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "FandomCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEvent_FandomEvents_eventsEventId",
                        column: x => x.eventsEventId,
                        principalTable: "FandomEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventFandom",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FandomsFandomId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFandom", x => new { x.EventsEventId, x.FandomsFandomId });
                    table.ForeignKey(
                        name: "FK_EventFandom_FandomEvents_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "FandomEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventFandom_Fandoms_FandomsFandomId",
                        column: x => x.FandomsFandomId,
                        principalTable: "Fandoms",
                        principalColumn: "FandomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEvent_eventsEventId",
                table: "CategoryEvent",
                column: "eventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFandom_FandomsFandomId",
                table: "EventFandom",
                column: "FandomsFandomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEvent");

            migrationBuilder.DropTable(
                name: "EventFandom");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "FandomCategories",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FandomCategories_EventId",
                table: "FandomCategories",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomCategories_FandomEvents_EventId",
                table: "FandomCategories",
                column: "EventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId");
        }
    }
}
