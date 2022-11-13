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
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false)
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    IsDiabled = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassroomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.SetNull);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedTask_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbsentHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbsentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsentHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_AbsentHistory_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbsentHistory_User_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoFillClassroom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoFillTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_AssignedTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "AssignedTask",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "ClassroomId", "ClassroomName", "EndYear", "Grade", "StartYear" },
                values: new object[,]
                {
                    { 1, "10 Sinh", 2018, "10", 2015 },
                    { 2, "10 Toan", 2018, "10", 2015 }
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
                    { 1, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dao", 0, false, false, "Quy Vuong", "$2a$11$kuOdE1.zSFZaCAIE.nfwauvnG.XfOZR6/Tt1EYEM1CDM2L1fc2cVS", 0, "AD1", "Admin" },
                    { 2, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do", 0, false, false, "Duy Nam", "$2a$11$kiv.nRzrs2fPgcl0beTmI.mREhGSgFnXiz3j6OvTzhjBwaRXmRId6", 1, "TC1", "Teacher" },
                    { 3, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do", 1, false, false, "Thu Huong", "$2a$11$SfhVF3rUd9GaHSPldtyU6uKKQIHUsZHhJKmMjwstK7b48w7nQRWrK", 1, "TC2", "Teacher1" }
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
                    { 1, 1, "10 Sinh", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le", 1, false, false, "Thi Van", "$2a$11$4qbEi2e0P6Q70VUEFAkfQO8ZzBqRaQ2Ust6ciEc7ZXmpaVTJ5az6a", 2, "ST1", "Student1" },
                    { 2, 1, "10 Sinh", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", 0, false, false, "Van A", "$2a$11$/mkIIV67oocfPWjcsChtN.TGRig5fT1CoGfYTp9BapH.Mi6Lt.sVq", 2, "ST2", "Student2" },
                    { 3, 2, "10 Toan", new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen", 0, false, false, "Van B", "$2a$11$2.Dxe66GKqVmE1DmDhxLWuHVGYyF67tv0.LCnlFjSlNUwf9QNTAMu", 2, "ST4", "Student3" }
                });

            migrationBuilder.InsertData(
                table: "AbsentHistory",
                columns: new[] { "HistoryId", "AbsentDate", "ClassroomName", "CreatedDate", "Reason", "StudentCode", "StudentFullName", "StudentId", "SubjectName", "TeacherFullName", "TeacherId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "10 Sinh", new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "ST1", "Dao Quy Vuong", 1, "Sinh", "Do Duy Nam", 2 },
                    { 2, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "10 Sinh", new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "No", "ST1", "Dao Quy Vuong", 1, "Toan", "Do Thu Huong", 3 }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "ScheduleId", "AutoFillClassroom", "AutoFillTeacher", "ClassroomId", "Day", "Period", "ScheduleDate", "Session", "TaskId", "UserId" },
                values: new object[,]
                {
                    { 1, "Sinh - Teacher", "Sinh - 10 Sinh", 1, 0, 1, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 2 },
                    { 2, "Toan - Teacher", "Toan - 10 Sinh", 1, 0, 2, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 2 },
                    { 3, "Toan - Teacher", "Toan - 10 Sinh", 1, 0, 2, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbsentHistory_StudentId",
                table: "AbsentHistory",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsentHistory_TeacherId",
                table: "AbsentHistory",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTask_SubjectId",
                table: "AssignedTask",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTask_UserId",
                table: "AssignedTask",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClassroomId",
                table: "Schedule",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TaskId",
                table: "Schedule",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_UserId",
                table: "Schedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomId",
                table: "Student",
                column: "ClassroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsentHistory");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AssignedTask");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
