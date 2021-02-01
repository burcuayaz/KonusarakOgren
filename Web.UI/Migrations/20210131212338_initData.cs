using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.UI.Migrations
{
    public partial class initData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExamGuid",
                table: "Exam",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Exam",
                newName: "ExamGuid");
        }
    }
}
