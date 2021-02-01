using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.UI.Migrations
{
    public partial class ExamResult1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Question_QuestionId",
                table: "ExamResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_QuestionId",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "ExamResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "ExamResult",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_QuestionId",
                table: "ExamResult",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Question_QuestionId",
                table: "ExamResult",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
