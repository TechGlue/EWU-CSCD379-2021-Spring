using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class onModelEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupsGroupId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Users_UsersUserId",
                table: "GroupUser");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_FirstName_LastName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Groups_Name",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Gifts_Title_UserId",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Gifts",
                newName: "Gift");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_FirstName_LastName",
                table: "User",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Group_Name",
                table: "Group",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Gift_Title_UserId",
                table: "Gift",
                columns: new[] { "Title", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gift",
                table: "Gift",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Gift_Title_UserId",
                table: "Gift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gift",
                table: "Gift");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Gift",
                newName: "Gifts");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_FirstName_LastName",
                table: "Users",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Groups_Name",
                table: "Groups",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Gifts_Title_UserId",
                table: "Gifts",
                columns: new[] { "Title", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupsGroupId",
                table: "GroupUser",
                column: "GroupsGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Users_UsersUserId",
                table: "GroupUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
