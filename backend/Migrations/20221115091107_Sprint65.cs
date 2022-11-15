using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Sprint65 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "ScheduleId", "AutoFillClassroom", "AutoFillTeacher", "ClassroomId", "Day", "Period", "ScheduleDate", "Session", "TaskId", "UserId" },
                values: new object[] { 4, "Toan - Teacher", "Toan - 10 Sinh", 1, 0, 1, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rE33u17PhALi45f42cassej7ZHQDOANaNujjbjrz1LmB4clgkRj82");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$Fs8CDf6Uow.gq2hK/IKHXem2DHIkTPEjq0c6fKO6/tS357SdEK6g6");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$SF36HSCzeu2AffXIjLFWJ.c0ci45xPz8q33g7Dvm1DAhltGuucue6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$TafpX5MP2YAZryhqEJ/sA.FQPjSk2LsZsQz3TIF4KPEyrnPjhUoXS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$93KJSwkNc/D1YI17iJlGm.e.0k4Cm523gbRgyeAO8GAp3SlLeXrn6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$I2UmG7ius.jrXIhNKOe4huHotUXSAA0.OxGF.Rr4umbHpN3Y9Y0Fe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "ScheduleId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$apHzG3ah3Lz/fG2Y4xoIJ.i9WXHUKOTzu/A.cqKsKr52sOCOyQIw6");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$mhU55fS/9cEp8iyfZGBadem8187Nk8Xv8YFxNFlkVjdXxuo/lYdj.");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$9..XGtgfjAvzDgRNoYYgsObFgEuFvJpECf0fdHZds86P3UHPhJVPC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ItK36I6Yj3vTSxaSTBQVFummPqejpN/J1j3aO7yrxUVP9C.wO659y");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$kbETqLyhv4VdFPegPFl9ROYumSGaHwTjuI/1kUTqdtp/089QfQMRa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$NHrj7RxCRHVFNjgf99JXoOihXIUriBmH2pg5tbVvd7TgvSOikiPmC");
        }
    }
}
