using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Sprint3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$t4P9kGXMw8BCUqv6IQXZ0.BV4P3CqPObEBHBpQdZ8Eji/0eWc8w/u");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$LonX0U1DEsH2VxUUhywxe.NeT7V7ryyTLMhJpQts71avxFMzmg5Hi");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$VIKY6Mmb4GLDiMzGQt1nyuG9U8qqMsqUEgqnozjZ/.QOxWXUruoB6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$owC5ZyXXSDpsDtIsqv0zkeMcDvlaGO.pQGFlly.gu1P7QLNdLQj7e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$Y5E9mARMNoAYICBIyL68U..zn8tkwTF6VtOvHCg.fJy98KU/62glO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$u9rCX3VsC5z4C1Zn0vB2D.yjkaDE6mxqDEERU21N7gffth98ZqVR6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tnHVFWLEKPiSu0rHZqJieuZcw6kXgIRgbT4gog2mWSCHXcs5.R80y");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$5ubPA7O3e0hHp91DxHZ/Fe.PkHqYiiLl72Px8jaQvIOXlFvYudFXC");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$2aWR8mvDYTnoFULgoH/jaueZuYUw7oUSyzJaZiTt91VwNZnS6epaS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$2MU5c8zjysBb4bgVdixiK.Jjctb.csiu5x0x9zVtAh2cFzk7HOXC2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$4i3Zsy533ril/nXmY.UHOO11FyTc1qSaGjK38R0IYaq8WsCCj8tNW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$nbvpkdDo8hIKj3ZbjBNSW.jnTG6vPYQxj7rugxu5gnG1ZctclBbAq");
        }
    }
}
