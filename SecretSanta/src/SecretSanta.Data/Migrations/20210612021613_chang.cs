using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class chang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Groups_Name",
                table: "Groups");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Gift_Title_UserId",
                table: "Gift");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Assignment_GiverAndReceiver",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Gift",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "GiverAndReceiver",
                table: "Assignment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Gift",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
                name: "AK_Groups_Name",
                table: "Groups",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Gift_Title_UserId",
                table: "Gift",
                columns: new[] { "Title", "UserId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Assignment_GiverAndReceiver",
                table: "Assignment",
                column: "GiverAndReceiver");
        }
    }
}
