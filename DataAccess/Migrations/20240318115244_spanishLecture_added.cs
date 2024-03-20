using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class spanishLecture_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpanishLectures",
                columns: table => new
                {
                    SpanishLectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpanishSubTopicId = table.Column<int>(type: "int", nullable: false),
                    SpanishSubTopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpanishSubTopicImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpanishSubTopicContents1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpanishSubTopicContents2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpanishSubTopicIsActive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpanishLectures", x => x.SpanishLectureId);
                    table.ForeignKey(
                        name: "FK_SpanishLectures_SpanishSubTopics_SpanishSubTopicId",
                        column: x => x.SpanishSubTopicId,
                        principalTable: "SpanishSubTopics",
                        principalColumn: "SpanishSubTopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpanishLectures_SpanishSubTopicId",
                table: "SpanishLectures",
                column: "SpanishSubTopicId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpanishLectures");
        }
    }
}
