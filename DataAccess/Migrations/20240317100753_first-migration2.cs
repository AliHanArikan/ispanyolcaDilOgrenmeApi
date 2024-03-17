using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class firstmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpanishTopics",
                columns: table => new
                {
                    SpanishTopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpanishTopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonLevel = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpanishTopics", x => x.SpanishTopicId);
                });

            migrationBuilder.CreateTable(
                name: "SpanishSubTopics",
                columns: table => new
                {
                    SpanishSubTopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpanishTopicId = table.Column<int>(type: "int", nullable: false),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTopicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTopicDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTopicPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpanishSubTopics", x => x.SpanishSubTopicId);
                    table.ForeignKey(
                        name: "FK_SpanishSubTopics_SpanishTopics_SpanishTopicId",
                        column: x => x.SpanishTopicId,
                        principalTable: "SpanishTopics",
                        principalColumn: "SpanishTopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpanishSubTopics_SpanishTopicId",
                table: "SpanishSubTopics",
                column: "SpanishTopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpanishSubTopics");

            migrationBuilder.DropTable(
                name: "SpanishTopics");
        }
    }
}
