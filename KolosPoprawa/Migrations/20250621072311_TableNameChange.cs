using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolosPoprawa.Migrations
{
    /// <inheritdoc />
    public partial class TableNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Languages_LanguageId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Students_StudentId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Tasks_TaskId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Records",
                newName: "Record");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_Records_TaskId",
                table: "Record",
                newName: "IX_Record_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_StudentId",
                table: "Record",
                newName: "IX_Record_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_LanguageId",
                table: "Record",
                newName: "IX_Record_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record",
                table: "Record",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Language_LanguageId",
                table: "Record",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Student_StudentId",
                table: "Record",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Task_TaskId",
                table: "Record",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Language_LanguageId",
                table: "Record");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Student_StudentId",
                table: "Record");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Task_TaskId",
                table: "Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Record",
                table: "Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Record",
                newName: "Records");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameIndex(
                name: "IX_Record_TaskId",
                table: "Records",
                newName: "IX_Records_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Record_StudentId",
                table: "Records",
                newName: "IX_Records_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Record_LanguageId",
                table: "Records",
                newName: "IX_Records_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Languages_LanguageId",
                table: "Records",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Students_StudentId",
                table: "Records",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Tasks_TaskId",
                table: "Records",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
