using Microsoft.EntityFrameworkCore.Migrations;

namespace DbRepository.Migrations
{
    public partial class AddSongTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tabs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Tempo = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    SongID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tabs_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrumIteration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrumTabID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrumIteration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DrumIteration_Tabs_DrumTabID",
                        column: x => x.DrumTabID,
                        principalTable: "Tabs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuitarIteration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarTabID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarIteration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GuitarIteration_Tabs_GuitarTabID",
                        column: x => x.GuitarTabID,
                        principalTable: "Tabs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrumNote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drum = table.Column<int>(nullable: false),
                    DrumIterationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrumNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DrumNote_DrumIteration_DrumIterationID",
                        column: x => x.DrumIterationID,
                        principalTable: "DrumIteration",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuitarNote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fret = table.Column<int>(nullable: false),
                    String = table.Column<int>(nullable: false),
                    GuitarIterationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GuitarNote_GuitarIteration_GuitarIterationID",
                        column: x => x.GuitarIterationID,
                        principalTable: "GuitarIteration",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrumIteration_DrumTabID",
                table: "DrumIteration",
                column: "DrumTabID");

            migrationBuilder.CreateIndex(
                name: "IX_DrumNote_DrumIterationID",
                table: "DrumNote",
                column: "DrumIterationID");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarIteration_GuitarTabID",
                table: "GuitarIteration",
                column: "GuitarTabID");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarNote_GuitarIterationID",
                table: "GuitarNote",
                column: "GuitarIterationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_SongID",
                table: "Tabs",
                column: "SongID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrumNote");

            migrationBuilder.DropTable(
                name: "GuitarNote");

            migrationBuilder.DropTable(
                name: "DrumIteration");

            migrationBuilder.DropTable(
                name: "GuitarIteration");

            migrationBuilder.DropTable(
                name: "Tabs");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
