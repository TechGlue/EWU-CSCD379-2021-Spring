using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class addedGiftstoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 1, "Pedro's pizza" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 2, "Pedro's Diner" });

            migrationBuilder.CreateIndex(
                name: "IX_Gift_UserId",
                table: "Gift",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gift_Users_UserId",
                table: "Gift",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gift_Users_UserId",
                table: "Gift");

            migrationBuilder.DropIndex(
                name: "IX_Gift_UserId",
                table: "Gift");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2);
        }
    }
}
