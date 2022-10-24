using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Sprint4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbsentHistory",
                keyColumn: "HistoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 24, 20, 22, 25, 385, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "AbsentHistory",
                keyColumn: "HistoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 24, 20, 22, 25, 385, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$B8u5p.D7JIADPSjZKS9TC.cBFXgGI./JeMGo4221ESp6cWTx00L9O");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$LV69lR27SiWW135PIrTUVeB7/6.IdJUuHaFLI1wRwCimHouU1v60S");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$q3Eq9bQwkGC3Z7/B9t4nveDjfIuM6F0yGGoXgqsvx3YN1Tv5oHHKi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$kvLU47GTIJpGkcctpPaTeubQ.cyOIAaQwS.ubYLhYNqGnOQ.055dq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$HzGn8N/8lgYibNvKX8yameFK516YVk7qKI8w6n/mCLL6Pn9THRdGW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$Tc5Gg0srLkAIwX2re6aQvO/EMPAnn2nmmtZ4KZ43jOkILK8kA0Iwm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbsentHistory",
                keyColumn: "HistoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 24, 20, 21, 55, 597, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "AbsentHistory",
                keyColumn: "HistoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 24, 20, 21, 55, 597, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$HITd3o9vhawJQRq1cE3DHeruV.4pSDiEoc2UyuK5GSHcjoLsJj9ZO");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$lky7b1K6AD3CaWroEChduu7m0q8QzsXcbyFV0U/UDrNB599JilUd2");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$hqN4JUQ63ApDR8H2eas6deeoDx/BdjDvsQPg.rIKlzJjGI4Qp6Kwm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$GoMA./AhJ1fAeDbBYPbzFe5wqAlnkQPyf5IaAXVSS.O/l5DPEHffS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$RwBocNtz8RxWNHvV7NDhwOfZL5ypB9WA/bL0/gjjC9oIMA1mNHWce");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$M.Qmza84B439d17iOKhmb.aHzA7m/h4wLiwkSXW9TLBR32dUJ9EOu");
        }
    }
}
