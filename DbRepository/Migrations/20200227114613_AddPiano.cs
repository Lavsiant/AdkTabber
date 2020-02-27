using Microsoft.EntityFrameworkCore.Migrations;

namespace DbRepository.Migrations
{
    public partial class AddPiano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Songs_SongID",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "Tempo",
                table: "Tabs");

            migrationBuilder.AlterColumn<int>(
                name: "SongID",
                table: "Tabs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Band",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tempo",
                table: "Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Songs_SongID",
                table: "Tabs",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Songs_SongID",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "Band",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Tempo",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "SongID",
                table: "Tabs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Tempo",
                table: "Tabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Songs_SongID",
                table: "Tabs",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
