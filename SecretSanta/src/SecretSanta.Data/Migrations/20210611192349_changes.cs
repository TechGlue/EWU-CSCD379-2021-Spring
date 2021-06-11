using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiverUserId",
                table: "Assignment",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "Assignment",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_GiverUserId",
                table: "Assignment",
                column: "GiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ReceiverUserId",
                table: "Assignment",
                column: "ReceiverUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_User_GiverUserId",
                table: "Assignment",
                column: "GiverUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_User_ReceiverUserId",
                table: "Assignment",
                column: "ReceiverUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_User_GiverUserId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_User_ReceiverUserId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_GiverUserId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_ReceiverUserId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "GiverUserId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "Assignment");
        }
    }
}
