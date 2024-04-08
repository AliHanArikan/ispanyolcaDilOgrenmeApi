using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class spanishLecture_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpanishSubTopicName",
                table: "SpanishLectures",
                newName: "SpanishLectureTopicName");

            migrationBuilder.RenameColumn(
                name: "SpanishSubTopicIsActive",
                table: "SpanishLectures",
                newName: "SpanishLectureTopicImage");

            migrationBuilder.RenameColumn(
                name: "SpanishSubTopicImage",
                table: "SpanishLectures",
                newName: "SpanishLectureIsActive");

            migrationBuilder.RenameColumn(
                name: "SpanishSubTopicContents2",
                table: "SpanishLectures",
                newName: "SpanishLectureContents2");

            migrationBuilder.RenameColumn(
                name: "SpanishSubTopicContents1",
                table: "SpanishLectures",
                newName: "SpanishLectureContents1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpanishLectureTopicName",
                table: "SpanishLectures",
                newName: "SpanishSubTopicName");

            migrationBuilder.RenameColumn(
                name: "SpanishLectureTopicImage",
                table: "SpanishLectures",
                newName: "SpanishSubTopicIsActive");

            migrationBuilder.RenameColumn(
                name: "SpanishLectureIsActive",
                table: "SpanishLectures",
                newName: "SpanishSubTopicImage");

            migrationBuilder.RenameColumn(
                name: "SpanishLectureContents2",
                table: "SpanishLectures",
                newName: "SpanishSubTopicContents2");

            migrationBuilder.RenameColumn(
                name: "SpanishLectureContents1",
                table: "SpanishLectures",
                newName: "SpanishSubTopicContents1");
        }
    }
}
