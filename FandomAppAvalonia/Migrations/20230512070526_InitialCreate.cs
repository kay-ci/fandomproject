using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomAppSpace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Salt = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    Hash = table.Column<byte[]>(type: "RAW(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "EVENTS",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MinAge = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTS", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_EVENTS_USERS_UserID",
                        column: x => x.UserID,
                        principalTable: "USERS",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MESSAGES",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Timesent = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Seen = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Sent = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MESSAGES", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_MESSAGES_USERS_UserID",
                        column: x => x.UserID,
                        principalTable: "USERS",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROFILES",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pronouns = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Picture = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Interests = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFILES", x => x.ProfileID);
                    table.ForeignKey(
                        name: "FK_PROFILES_USERS_UserID",
                        column: x => x.UserID,
                        principalTable: "USERS",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    AttendeesUserID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventsAttendingEventID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.AttendeesUserID, x.EventsAttendingEventID });
                    table.ForeignKey(
                        name: "FK_EventUser_EVENTS_EventsAttendingEventID",
                        column: x => x.EventsAttendingEventID,
                        principalTable: "EVENTS",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_USERS_AttendeesUserID",
                        column: x => x.AttendeesUserID,
                        principalTable: "USERS",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageUser",
                columns: table => new
                {
                    InboxMessageID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecipientsUserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUser", x => new { x.InboxMessageID, x.RecipientsUserID });
                    table.ForeignKey(
                        name: "FK_MessageUser_MESSAGES_InboxMessageID",
                        column: x => x.InboxMessageID,
                        principalTable: "MESSAGES",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUser_USERS_RecipientsUserID",
                        column: x => x.RecipientsUserID,
                        principalTable: "USERS",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BADGES",
                columns: table => new
                {
                    BadgeID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BadgeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProfileID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BADGES", x => x.BadgeID);
                    table.ForeignKey(
                        name: "FK_BADGES_PROFILES_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "PROFILES",
                        principalColumn: "ProfileID");
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProfileID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_CATEGORIES_PROFILES_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "PROFILES",
                        principalColumn: "ProfileID");
                });

            migrationBuilder.CreateTable(
                name: "FANDOMS",
                columns: table => new
                {
                    FandomID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ProfileID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FANDOMS", x => x.FandomID);
                    table.ForeignKey(
                        name: "FK_FANDOMS_PROFILES_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "PROFILES",
                        principalColumn: "ProfileID");
                });

            migrationBuilder.CreateTable(
                name: "CategoryEvent",
                columns: table => new
                {
                    CategoriesCategoryID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    eventsEventID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEvent", x => new { x.CategoriesCategoryID, x.eventsEventID });
                    table.ForeignKey(
                        name: "FK_CategoryEvent_CATEGORIES_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "CATEGORIES",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEvent_EVENTS_eventsEventID",
                        column: x => x.eventsEventID,
                        principalTable: "EVENTS",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventFandom",
                columns: table => new
                {
                    EventsEventID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FandomsFandomID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFandom", x => new { x.EventsEventID, x.FandomsFandomID });
                    table.ForeignKey(
                        name: "FK_EventFandom_EVENTS_EventsEventID",
                        column: x => x.EventsEventID,
                        principalTable: "EVENTS",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventFandom_FANDOMS_FandomsFandomID",
                        column: x => x.FandomsFandomID,
                        principalTable: "FANDOMS",
                        principalColumn: "FandomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FandomUser",
                columns: table => new
                {
                    FandomsFandomID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FansUserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomUser", x => new { x.FandomsFandomID, x.FansUserID });
                    table.ForeignKey(
                        name: "FK_FandomUser_FANDOMS_FandomsFandomID",
                        column: x => x.FandomsFandomID,
                        principalTable: "FANDOMS",
                        principalColumn: "FandomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FandomUser_USERS_FansUserID",
                        column: x => x.FansUserID,
                        principalTable: "USERS",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BADGES_ProfileID",
                table: "BADGES",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_ProfileID",
                table: "CATEGORIES",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEvent_eventsEventID",
                table: "CategoryEvent",
                column: "eventsEventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventFandom_FandomsFandomID",
                table: "EventFandom",
                column: "FandomsFandomID");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTS_UserID",
                table: "EVENTS",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventsAttendingEventID",
                table: "EventUser",
                column: "EventsAttendingEventID");

            migrationBuilder.CreateIndex(
                name: "IX_FANDOMS_ProfileID",
                table: "FANDOMS",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_FandomUser_FansUserID",
                table: "FandomUser",
                column: "FansUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MESSAGES_UserID",
                table: "MESSAGES",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_RecipientsUserID",
                table: "MessageUser",
                column: "RecipientsUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PROFILES_UserID",
                table: "PROFILES",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BADGES");

            migrationBuilder.DropTable(
                name: "CategoryEvent");

            migrationBuilder.DropTable(
                name: "EventFandom");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "FandomUser");

            migrationBuilder.DropTable(
                name: "MessageUser");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "EVENTS");

            migrationBuilder.DropTable(
                name: "FANDOMS");

            migrationBuilder.DropTable(
                name: "MESSAGES");

            migrationBuilder.DropTable(
                name: "PROFILES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
