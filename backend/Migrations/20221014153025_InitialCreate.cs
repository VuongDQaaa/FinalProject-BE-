using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    IsDiabled = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    IsDiabled = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignedTask",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoFill = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTask", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_AssignedTask_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignedTask_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "ClassroomId", "ClassroomName" },
                values: new object[,]
                {
                    { 1, "10 Sinh" },
                    { 2, "10 Toan" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[,]
                {
                    { 1, "Sinh" },
                    { 2, "Toan" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "Gender", "IsDiabled", "IsFirstLogin", "LastName", "PasswordHash", "Role", "UserCode", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dao", 0, false, false, "Quy Vuong", "$2a$11$2MU5c8zjysBb4bgVdixiK.Jjctb.csiu5x0x9zVtAh2cFzk7HOXC2", 0, "AD1", "Admin" },
                    { 2, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do", 0, false, false, "Duy Nam", "$2a$11$4i3Zsy533ril/nXmY.UHOO11FyTc1qSaGjK38R0IYaq8WsCCj8tNW", 1, "TC1", "Teacher" },
                    { 3, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do", 1, false, false, "Thu Huong", "$2a$11$nbvpkdDo8hIKj3ZbjBNSW.jnTG6vPYQxj7rugxu5gnG1ZctclBbAq", 1, "TC2", "Teacher1" }
                });

            migrationBuilder.InsertData(
                table: "AssignedTask",
                columns: new[] { "TaskId", "AutoFill", "SubjectId", "SubjectName", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "Teacher - Sinh", 1, "Sinh", 2, "Teacher" },
                    { 2, "Teacher - Toan", 2, "Toan", 2, "Teacher" },
                    { 3, "Teacher1 - Toan", 2, "Toan", 3, "Teacher1" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "ClassroomId", "ClassroomName", "DateOfBirth", "FirstName", "Gender", "IsDiabled", "IsFirstLogin", "LastName", "PasswordHash", "Role", "StudentCode", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "10 Sinh", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le", 1, false, false, "Thi Van", "$2a$11$tnHVFWLEKPiSu0rHZqJieuZcw6kXgIRgbT4gog2mWSCHXcs5.R80y", 2, "ST1", "Student1" },
                    { 2, 1, "10 Sinh", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", 0, false, false, "Van A", "$2a$11$5ubPA7O3e0hHp91DxHZ/Fe.PkHqYiiLl72Px8jaQvIOXlFvYudFXC", 2, "ST2", "Student2" },
                    { 3, 2, "10 Toan", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", 0, false, false, "Van B", "$2a$11$2aWR8mvDYTnoFULgoH/jaueZuYUw7oUSyzJaZiTt91VwNZnS6epaS", 2, "ST4", "Student3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTask_SubjectId",
                table: "AssignedTask",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTask_UserId",
                table: "AssignedTask",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomId",
                table: "Student",
                column: "ClassroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedTask");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Classroom");
        }
    }
}
