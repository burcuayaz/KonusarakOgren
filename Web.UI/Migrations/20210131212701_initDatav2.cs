using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.UI.Migrations
{
    public partial class initDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Exam",
                newName: "QuestionMain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionMain",
                table: "Exam",
                newName: "Url");
        }
    }
}
