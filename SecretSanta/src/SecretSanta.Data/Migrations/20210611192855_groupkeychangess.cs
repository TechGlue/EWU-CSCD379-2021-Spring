using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class groupkeychangess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Group_GroupId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Group_GroupsGroupId",
                table: "GroupUser");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Group_Name",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Groups_GroupId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupsGroupId",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Group_Name",
                table: "Group",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupId");

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
        }
    }
}
