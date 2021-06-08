using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class changesDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Group_GroupId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Group_GroupsGroupId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_User_UsersUserId",
                table: "GroupUser");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Assignment_GiverAndReceiver",
                table: "Assignment");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_FirstName_LastName",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Group_Name",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Speakers");

            migrationBuilder.AlterColumn<string>(
                name: "GiverAndReceiver",
                table: "Assignment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Events_FirstName_LastName",
                table: "Events",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Speakers_GroupId",
                table: "Assignment",
                column: "GroupId",
                principalTable: "Speakers",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Events_UsersUserId",
                table: "GroupUser",
                column: "UsersUserId",
                principalTable: "Events",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Speakers_GroupsGroupId",
                table: "GroupUser",
                column: "GroupsGroupId",
                principalTable: "Speakers",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Speakers_GroupId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Events_UsersUserId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Speakers_GroupsGroupId",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Events_FirstName_LastName",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Speakers",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "GiverAndReceiver",
                table: "Assignment",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Assignment_GiverAndReceiver",
                table: "Assignment",
                column: "GiverAndReceiver");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Group_Name",
                table: "Group",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_FirstName_LastName",
                table: "User",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    GiftId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.GiftId);
                    table.UniqueConstraint("AK_Gift_Title_UserId", x => new { x.Title, x.UserId });
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "LastName" },
                values: new object[] { 1, "Luis", "Garcia" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Group_GroupId",
                table: "Assignment",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Group_GroupsGroupId",
                table: "GroupUser",
                column: "GroupsGroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_User_UsersUserId",
                table: "GroupUser",
                column: "UsersUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
