using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makeConfigForAllTAblesUsingFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_Departments_DID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_subjects_SubID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubjects_Instructors_InsId",
                table: "InstructorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubjects_subjects_SubId",
                table: "InstructorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Departments_DID",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_studentSubjects_students_StudID",
                table: "studentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_studentSubjects_subjects_SubID",
                table: "studentSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_Departments_DID",
                table: "departmetSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_subjects_SubID",
                table: "departmetSubjects",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubjects_Instructors_InsId",
                table: "InstructorSubjects",
                column: "InsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubjects_subjects_SubId",
                table: "InstructorSubjects",
                column: "SubId",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_students_Departments_DID",
                table: "students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studentSubjects_students_StudID",
                table: "studentSubjects",
                column: "StudID",
                principalTable: "students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studentSubjects_subjects_SubID",
                table: "studentSubjects",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_Departments_DID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_subjects_SubID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubjects_Instructors_InsId",
                table: "InstructorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubjects_subjects_SubId",
                table: "InstructorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Departments_DID",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_studentSubjects_students_StudID",
                table: "studentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_studentSubjects_subjects_SubID",
                table: "studentSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_Departments_DID",
                table: "departmetSubjects",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_subjects_SubID",
                table: "departmetSubjects",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubjects_Instructors_InsId",
                table: "InstructorSubjects",
                column: "InsId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubjects_subjects_SubId",
                table: "InstructorSubjects",
                column: "SubId",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_Departments_DID",
                table: "students",
                column: "DID",
                principalTable: "Departments",
                principalColumn: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_studentSubjects_students_StudID",
                table: "studentSubjects",
                column: "StudID",
                principalTable: "students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentSubjects_subjects_SubID",
                table: "studentSubjects",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
