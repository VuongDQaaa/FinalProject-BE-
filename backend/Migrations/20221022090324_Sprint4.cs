using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Sprint4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$uY/Hk3fP/cuU1SBey6KUm.py2qAtSrVP8iX7NeI72WYJooPbkew7W");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$tujhn88VueFsYUrLKupyAOwSgLYcOQ2dy8SYBg5jTzFsBLx3UA34K");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$W2NOpV3IdTfaMh5zgZpfUuwuZII3N0KhSQ39PdQsXi4hjIGS2A4.O");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$8KY/2lOYhiyW8IYRGVgi9OFaLm/ZDvQg.BIXFyqHbJb9gyJZvoWau");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$cPV9dRuSv5IHV2e9iXdORei0arwGuGyR1ahnfhk0qqKNjKAo4d1J.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$HMmWX7nwEuE7opWM2pR5Uux7R1Wi8kUlstbPdHvPD3TcUJMRezGlG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$L8gCXJrDJY4YO70sta4mbu8rmqp0HeBggU9rqCa6zD4oEt3E2QiZ.");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$f/G/ht.3RL/.3QaHkKohDePo0JykcSpbS7W24C5dk6iDMm8ItbyMW");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$15wEmtwOJ9Nm/MHnMuDkceiuO3q97T.9OyWti2/SuvlbjuR/rW116");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$RCqDxJ4VXLHn369i9JgpyeOKX0kzU0a/E3G9B2He1EaJe.VlQxpcO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$29AzbXmGIH4UbgeuSzv.7eNfl4AkTKwt81UdqX9cXltNK/u7qm.DC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$z95FVZSLV1yk4ha4nSE3rONLygDXxgU8P38kuzdR2kpljcB3daMHG");
        }
    }
}
