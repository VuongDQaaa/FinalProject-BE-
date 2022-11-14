using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Sprint5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xPGKoGktyshoQRdqPEkrzuVJyvCp0dPYBdN9gEi8Bg8wX9QRjVnxa");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$IL2xoa6eHNaQLAYC6x15j./yIYZ9pvVrEyoJvLA2QZ3PVpDCvtq.G");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$C/9TDd8ylDApITYv8sr8Xe9MupXkGozAcLT3yTu4EpgUE00ekU1eq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$T4CU9WyaSdWfYXF.wx8ivu3/BjfUr8b0unmpq49deT.ZHOrdBYhK.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$cRG/6EeG41GHl/UaTF/FN.6skrpIpeaHnH/cmzUfoUJS4aUDAt/4e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$XUx/5qYq9PXHRMnbt7TguOC/W9SPb0JrylI9IyqQEWsUQUQJeRn.W");
        }
    }
}
