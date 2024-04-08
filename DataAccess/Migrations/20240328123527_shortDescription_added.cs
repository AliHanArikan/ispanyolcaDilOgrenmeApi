using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class shortDescription_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpanishShortDescriptions",
                columns: table => new
                {
                    SpanishShortDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpanishLectureId = table.Column<int>(type: "int", nullable: false),
                    ShortDescriptionPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpanishShortDescriptions", x => x.SpanishShortDescriptionId);
                    table.ForeignKey(
                        name: "FK_SpanishShortDescriptions_SpanishLectures_SpanishLectureId",
                        column: x => x.SpanishLectureId,
                        principalTable: "SpanishLectures",
                        principalColumn: "SpanishLectureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpanishShortDescriptions_SpanishLectureId",
                table: "SpanishShortDescriptions",
                column: "SpanishLectureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpanishShortDescriptions");
        }
    }
}
