using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSanta.Data.Migrations
{
    public partial class groupkeychangessss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Assignment_GiverAndReceiver",
                table: "Assignment");

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
        }
    }
}
