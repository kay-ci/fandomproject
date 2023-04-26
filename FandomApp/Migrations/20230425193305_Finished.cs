using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class Finished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FandomEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MinAge = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomEvents", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "FandomUsers",
                columns: table => new
                {
                    userID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Hash = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    Salt = table.Column<byte[]>(type: "RAW(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomUsers", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    AttendeesuserID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventsEventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.AttendeesuserID, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_EventUser_FandomEvents_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "FandomEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_FandomUsers_AttendeesuserID",
                        column: x => x.AttendeesuserID,
                        principalTable: "FandomUsers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FandomProfiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Pronouns = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Picture = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Interests = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    userID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomProfiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_FandomProfiles_FandomUsers_userID",
                        column: x => x.userID,
                        principalTable: "FandomUsers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    BadgeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    bad_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.BadgeId);
                    table.ForeignKey(
                        name: "FK_Badge_FandomProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "FandomProfiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cat_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_FandomEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "FandomEvents",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK_Category_FandomProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "FandomProfiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateTable(
                name: "Fandoms",
                columns: table => new
                {
                    FandomId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fandoms", x => x.FandomId);
                    table.ForeignKey(
                        name: "FK_Fandoms_FandomProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "FandomProfiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateTable(
                name: "FandomMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Timesent = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Seen = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserMessageId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    UserMessageId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FandomMessages_FandomUserMessages_UserMessageId",
                        column: x => x.UserMessageId,
                        principalTable: "FandomUserMessages",
                        principalColumn: "UserMessageId");
                    table.ForeignKey(
                        name: "FK_FandomMessages_FandomUserMessages_UserMessageId1",
                        column: x => x.UserMessageId1,
                        principalTable: "FandomUserMessages",
                        principalColumn: "UserMessageId");
                });

            migrationBuilder.CreateTable(
                name: "FandomUser",
                columns: table => new
                {
                    FandomsFandomId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FansuserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FandomUser", x => new { x.FandomsFandomId, x.FansuserID });
                    table.ForeignKey(
                        name: "FK_FandomUser_FandomUsers_FansuserID",
                        column: x => x.FansuserID,
                        principalTable: "FandomUsers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FandomUser_Fandoms_FandomsFandomId",
                        column: x => x.FandomsFandomId,
                        principalTable: "Fandoms",
                        principalColumn: "FandomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_ProfileId",
                table: "Badge",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_EventId",
                table: "Category",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProfileId",
                table: "Category",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventsEventId",
                table: "EventUser",
                column: "EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FandomMessages_UserMessageId",
                table: "FandomMessages",
                column: "UserMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_FandomMessages_UserMessageId1",
                table: "FandomMessages",
                column: "UserMessageId1");

            migrationBuilder.CreateIndex(
                name: "IX_FandomProfiles_userID",
                table: "FandomProfiles",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fandoms_ProfileId",
                table: "Fandoms",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FandomUser_FansuserID",
                table: "FandomUser",
                column: "FansuserID");

            migrationBuilder.CreateIndex(
                name: "IX_FandomUserMessages_UserId",
                table: "FandomUserMessages",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "FandomMessages");

            migrationBuilder.DropTable(
                name: "FandomUser");

            migrationBuilder.DropTable(
                name: "FandomEvents");

            migrationBuilder.DropTable(
                name: "FandomUserMessages");

            migrationBuilder.DropTable(
                name: "Fandoms");

            migrationBuilder.DropTable(
                name: "FandomProfiles");

            migrationBuilder.DropTable(
                name: "FandomUsers");
        }
    }
}
