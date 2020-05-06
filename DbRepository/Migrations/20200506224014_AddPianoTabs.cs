using Microsoft.EntityFrameworkCore.Migrations;

namespace DbRepository.Migrations
{
    public partial class AddPianoTabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PianoIteration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeScale = table.Column<int>(nullable: false),
                    PianoTabID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PianoIteration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PianoIteration_Tabs_PianoTabID",
                        column: x => x.PianoTabID,
                        principalTable: "Tabs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteNote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(nullable: false),
                    Octave = table.Column<int>(nullable: false),
                    PianoIterationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConcreteNote_PianoIteration_PianoIterationID",
                        column: x => x.PianoIterationID,
                        principalTable: "PianoIteration",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteNote_PianoIterationID",
                table: "ConcreteNote",
                column: "PianoIterationID");

            migrationBuilder.CreateIndex(
                name: "IX_PianoIteration_PianoTabID",
                table: "PianoIteration",
                column: "PianoTabID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcreteNote");

            migrationBuilder.DropTable(
                name: "PianoIteration");
        }
    }
}
