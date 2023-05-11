using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTablesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvent_FandomCategories_CategoriesCategoryId",
                table: "CategoryEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvent_FandomEvents_eventsEventId",
                table: "CategoryEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_EventFandom_FandomEvents_EventsEventId",
                table: "EventFandom");

            migrationBuilder.DropForeignKey(
                name: "FK_EventFandom_Fandoms_FandomsFandomId",
                table: "EventFandom");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_FandomEvents_EventsAttendingEventId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_FandomUsers_AttendeesuserID",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomBadges_FandomProfiles_ProfileId",
                table: "FandomBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomCategories_FandomProfiles_ProfileId",
                table: "FandomCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomEvents_FandomUsers_userID",
                table: "FandomEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomMessages_FandomUsers_userID",
                table: "FandomMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomProfiles_FandomUsers_userID",
                table: "FandomProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Fandoms_FandomProfiles_ProfileId",
                table: "Fandoms");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomUser_FandomUsers_FansuserID",
                table: "FandomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomUser_Fandoms_FandomsFandomId",
                table: "FandomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_FandomMessages_InboxMessageId",
                table: "MessageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_FandomUsers_RecipientsuserID",
                table: "MessageUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fandoms",
                table: "Fandoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomUsers",
                table: "FandomUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomProfiles",
                table: "FandomProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomMessages",
                table: "FandomMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomEvents",
                table: "FandomEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomCategories",
                table: "FandomCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FandomBadges",
                table: "FandomBadges");

            migrationBuilder.RenameTable(
                name: "Fandoms",
                newName: "FANDOMS");

            migrationBuilder.RenameTable(
                name: "FandomUsers",
                newName: "USERS");

            migrationBuilder.RenameTable(
                name: "FandomProfiles",
                newName: "PROFILES");

            migrationBuilder.RenameTable(
                name: "FandomMessages",
                newName: "MESSAGES");

            migrationBuilder.RenameTable(
                name: "FandomEvents",
                newName: "EVENTS");

            migrationBuilder.RenameTable(
                name: "FandomCategories",
                newName: "CATEGORIES");

            migrationBuilder.RenameTable(
                name: "FandomBadges",
                newName: "BADGES");

            migrationBuilder.RenameColumn(
                name: "RecipientsuserID",
                table: "MessageUser",
                newName: "RecipientsUserID");

            migrationBuilder.RenameColumn(
                name: "InboxMessageId",
                table: "MessageUser",
                newName: "InboxMessageID");

            migrationBuilder.RenameIndex(
                name: "IX_MessageUser_RecipientsuserID",
                table: "MessageUser",
                newName: "IX_MessageUser_RecipientsUserID");

            migrationBuilder.RenameColumn(
                name: "FansuserID",
                table: "FandomUser",
                newName: "FansUserID");

            migrationBuilder.RenameColumn(
                name: "FandomsFandomId",
                table: "FandomUser",
                newName: "FandomsFandomID");

            migrationBuilder.RenameIndex(
                name: "IX_FandomUser_FansuserID",
                table: "FandomUser",
                newName: "IX_FandomUser_FansUserID");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "FANDOMS",
                newName: "ProfileID");

            migrationBuilder.RenameColumn(
                name: "FandomId",
                table: "FANDOMS",
                newName: "FandomID");

            migrationBuilder.RenameIndex(
                name: "IX_Fandoms_ProfileId",
                table: "FANDOMS",
                newName: "IX_FANDOMS_ProfileID");

            migrationBuilder.RenameColumn(
                name: "AttendeesuserID",
                table: "EventUser",
                newName: "AttendeesUserID");

            migrationBuilder.RenameColumn(
                name: "FandomsFandomId",
                table: "EventFandom",
                newName: "FandomsFandomID");

            migrationBuilder.RenameIndex(
                name: "IX_EventFandom_FandomsFandomId",
                table: "EventFandom",
                newName: "IX_EventFandom_FandomsFandomID");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategoryEvent",
                newName: "CategoriesCategoryID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "USERS",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "PROFILES",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "PROFILES",
                newName: "ProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_FandomProfiles_userID",
                table: "PROFILES",
                newName: "IX_PROFILES_UserID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "MESSAGES",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "MESSAGES",
                newName: "MessageID");

            migrationBuilder.RenameIndex(
                name: "IX_FandomMessages_userID",
                table: "MESSAGES",
                newName: "IX_MESSAGES_UserID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "EVENTS",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_FandomEvents_userID",
                table: "EVENTS",
                newName: "IX_EVENTS_UserID");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "CATEGORIES",
                newName: "ProfileID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CATEGORIES",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_FandomCategories_ProfileId",
                table: "CATEGORIES",
                newName: "IX_CATEGORIES_ProfileID");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "BADGES",
                newName: "ProfileID");

            migrationBuilder.RenameColumn(
                name: "BadgeId",
                table: "BADGES",
                newName: "BadgeID");

            migrationBuilder.RenameIndex(
                name: "IX_FandomBadges_ProfileId",
                table: "BADGES",
                newName: "IX_BADGES_ProfileID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FANDOMS",
                table: "FANDOMS",
                column: "FandomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERS",
                table: "USERS",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PROFILES",
                table: "PROFILES",
                column: "ProfileID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MESSAGES",
                table: "MESSAGES",
                column: "MessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EVENTS",
                table: "EVENTS",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIES",
                table: "CATEGORIES",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BADGES",
                table: "BADGES",
                column: "BadgeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BADGES_PROFILES_ProfileID",
                table: "BADGES",
                column: "ProfileID",
                principalTable: "PROFILES",
                principalColumn: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORIES_PROFILES_ProfileID",
                table: "CATEGORIES",
                column: "ProfileID",
                principalTable: "PROFILES",
                principalColumn: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvent_CATEGORIES_CategoriesCategoryID",
                table: "CategoryEvent",
                column: "CategoriesCategoryID",
                principalTable: "CATEGORIES",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvent_EVENTS_eventsEventId",
                table: "CategoryEvent",
                column: "eventsEventId",
                principalTable: "EVENTS",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventFandom_EVENTS_EventsEventId",
                table: "EventFandom",
                column: "EventsEventId",
                principalTable: "EVENTS",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventFandom_FANDOMS_FandomsFandomID",
                table: "EventFandom",
                column: "FandomsFandomID",
                principalTable: "FANDOMS",
                principalColumn: "FandomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EVENTS_USERS_UserID",
                table: "EVENTS",
                column: "UserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_EVENTS_EventsAttendingEventId",
                table: "EventUser",
                column: "EventsAttendingEventId",
                principalTable: "EVENTS",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_USERS_AttendeesUserID",
                table: "EventUser",
                column: "AttendeesUserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FANDOMS_PROFILES_ProfileID",
                table: "FANDOMS",
                column: "ProfileID",
                principalTable: "PROFILES",
                principalColumn: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomUser_FANDOMS_FandomsFandomID",
                table: "FandomUser",
                column: "FandomsFandomID",
                principalTable: "FANDOMS",
                principalColumn: "FandomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomUser_USERS_FansUserID",
                table: "FandomUser",
                column: "FansUserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MESSAGES_USERS_UserID",
                table: "MESSAGES",
                column: "UserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUser_MESSAGES_InboxMessageID",
                table: "MessageUser",
                column: "InboxMessageID",
                principalTable: "MESSAGES",
                principalColumn: "MessageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUser_USERS_RecipientsUserID",
                table: "MessageUser",
                column: "RecipientsUserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PROFILES_USERS_UserID",
                table: "PROFILES",
                column: "UserID",
                principalTable: "USERS",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BADGES_PROFILES_ProfileID",
                table: "BADGES");

            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORIES_PROFILES_ProfileID",
                table: "CATEGORIES");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvent_CATEGORIES_CategoriesCategoryID",
                table: "CategoryEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEvent_EVENTS_eventsEventId",
                table: "CategoryEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_EventFandom_EVENTS_EventsEventId",
                table: "EventFandom");

            migrationBuilder.DropForeignKey(
                name: "FK_EventFandom_FANDOMS_FandomsFandomID",
                table: "EventFandom");

            migrationBuilder.DropForeignKey(
                name: "FK_EVENTS_USERS_UserID",
                table: "EVENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_EVENTS_EventsAttendingEventId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_USERS_AttendeesUserID",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FANDOMS_PROFILES_ProfileID",
                table: "FANDOMS");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomUser_FANDOMS_FandomsFandomID",
                table: "FandomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FandomUser_USERS_FansUserID",
                table: "FandomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MESSAGES_USERS_UserID",
                table: "MESSAGES");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_MESSAGES_InboxMessageID",
                table: "MessageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_USERS_RecipientsUserID",
                table: "MessageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PROFILES_USERS_UserID",
                table: "PROFILES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FANDOMS",
                table: "FANDOMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USERS",
                table: "USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PROFILES",
                table: "PROFILES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MESSAGES",
                table: "MESSAGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EVENTS",
                table: "EVENTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIES",
                table: "CATEGORIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BADGES",
                table: "BADGES");

            migrationBuilder.RenameTable(
                name: "FANDOMS",
                newName: "Fandoms");

            migrationBuilder.RenameTable(
                name: "USERS",
                newName: "FandomUsers");

            migrationBuilder.RenameTable(
                name: "PROFILES",
                newName: "FandomProfiles");

            migrationBuilder.RenameTable(
                name: "MESSAGES",
                newName: "FandomMessages");

            migrationBuilder.RenameTable(
                name: "EVENTS",
                newName: "FandomEvents");

            migrationBuilder.RenameTable(
                name: "CATEGORIES",
                newName: "FandomCategories");

            migrationBuilder.RenameTable(
                name: "BADGES",
                newName: "FandomBadges");

            migrationBuilder.RenameColumn(
                name: "RecipientsUserID",
                table: "MessageUser",
                newName: "RecipientsuserID");

            migrationBuilder.RenameColumn(
                name: "InboxMessageID",
                table: "MessageUser",
                newName: "InboxMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageUser_RecipientsUserID",
                table: "MessageUser",
                newName: "IX_MessageUser_RecipientsuserID");

            migrationBuilder.RenameColumn(
                name: "FansUserID",
                table: "FandomUser",
                newName: "FansuserID");

            migrationBuilder.RenameColumn(
                name: "FandomsFandomID",
                table: "FandomUser",
                newName: "FandomsFandomId");

            migrationBuilder.RenameIndex(
                name: "IX_FandomUser_FansUserID",
                table: "FandomUser",
                newName: "IX_FandomUser_FansuserID");

            migrationBuilder.RenameColumn(
                name: "ProfileID",
                table: "Fandoms",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "FandomID",
                table: "Fandoms",
                newName: "FandomId");

            migrationBuilder.RenameIndex(
                name: "IX_FANDOMS_ProfileID",
                table: "Fandoms",
                newName: "IX_Fandoms_ProfileId");

            migrationBuilder.RenameColumn(
                name: "AttendeesUserID",
                table: "EventUser",
                newName: "AttendeesuserID");

            migrationBuilder.RenameColumn(
                name: "FandomsFandomID",
                table: "EventFandom",
                newName: "FandomsFandomId");

            migrationBuilder.RenameIndex(
                name: "IX_EventFandom_FandomsFandomID",
                table: "EventFandom",
                newName: "IX_EventFandom_FandomsFandomId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryID",
                table: "CategoryEvent",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "FandomUsers",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "FandomProfiles",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "ProfileID",
                table: "FandomProfiles",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_PROFILES_UserID",
                table: "FandomProfiles",
                newName: "IX_FandomProfiles_userID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "FandomMessages",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "FandomMessages",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_MESSAGES_UserID",
                table: "FandomMessages",
                newName: "IX_FandomMessages_userID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "FandomEvents",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_EVENTS_UserID",
                table: "FandomEvents",
                newName: "IX_FandomEvents_userID");

            migrationBuilder.RenameColumn(
                name: "ProfileID",
                table: "FandomCategories",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "FandomCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CATEGORIES_ProfileID",
                table: "FandomCategories",
                newName: "IX_FandomCategories_ProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileID",
                table: "FandomBadges",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "BadgeID",
                table: "FandomBadges",
                newName: "BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_BADGES_ProfileID",
                table: "FandomBadges",
                newName: "IX_FandomBadges_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fandoms",
                table: "Fandoms",
                column: "FandomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomUsers",
                table: "FandomUsers",
                column: "userID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomProfiles",
                table: "FandomProfiles",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomMessages",
                table: "FandomMessages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomEvents",
                table: "FandomEvents",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomCategories",
                table: "FandomCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FandomBadges",
                table: "FandomBadges",
                column: "BadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvent_FandomCategories_CategoriesCategoryId",
                table: "CategoryEvent",
                column: "CategoriesCategoryId",
                principalTable: "FandomCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEvent_FandomEvents_eventsEventId",
                table: "CategoryEvent",
                column: "eventsEventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventFandom_FandomEvents_EventsEventId",
                table: "EventFandom",
                column: "EventsEventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventFandom_Fandoms_FandomsFandomId",
                table: "EventFandom",
                column: "FandomsFandomId",
                principalTable: "Fandoms",
                principalColumn: "FandomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_FandomEvents_EventsAttendingEventId",
                table: "EventUser",
                column: "EventsAttendingEventId",
                principalTable: "FandomEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_FandomUsers_AttendeesuserID",
                table: "EventUser",
                column: "AttendeesuserID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomBadges_FandomProfiles_ProfileId",
                table: "FandomBadges",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomCategories_FandomProfiles_ProfileId",
                table: "FandomCategories",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomEvents_FandomUsers_userID",
                table: "FandomEvents",
                column: "userID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomMessages_FandomUsers_userID",
                table: "FandomMessages",
                column: "userID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomProfiles_FandomUsers_userID",
                table: "FandomProfiles",
                column: "userID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fandoms_FandomProfiles_ProfileId",
                table: "Fandoms",
                column: "ProfileId",
                principalTable: "FandomProfiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FandomUser_FandomUsers_FansuserID",
                table: "FandomUser",
                column: "FansuserID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FandomUser_Fandoms_FandomsFandomId",
                table: "FandomUser",
                column: "FandomsFandomId",
                principalTable: "Fandoms",
                principalColumn: "FandomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUser_FandomMessages_InboxMessageId",
                table: "MessageUser",
                column: "InboxMessageId",
                principalTable: "FandomMessages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUser_FandomUsers_RecipientsuserID",
                table: "MessageUser",
                column: "RecipientsuserID",
                principalTable: "FandomUsers",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
