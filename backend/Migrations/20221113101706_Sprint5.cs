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
                value: "$2a$11$xvgGsyltWQSf3PFguWmwSuE0CLflYMucOpZeV1dmU4sAyu8liznbO");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$N59XDhTS2KmgW.fvcaFYsOf2Y4Ly4z8q4rJjcSQDvu3XcGqCGTlOK");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$12LeIVSGPkriWWzO0ltNpu0qXvjOyQXilTJm3ovAVuoKwSr3.Nue6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$6QIW3s6nmWmIvg7jpBQy4uP3BlSmomz14uIR32t6LupjZBWELEeM6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$Xgt0p.6Pq0ang2gGrB6ZAuzDHoPnRGalOdzKWQmlcuRHaKQfo47hu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$aAXTmfofqEJbjoE9PHLq9.MNpnhC/ASKO6tYqnh61giM0LNCkLO8q");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$4qbEi2e0P6Q70VUEFAkfQO8ZzBqRaQ2Ust6ciEc7ZXmpaVTJ5az6a");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$/mkIIV67oocfPWjcsChtN.TGRig5fT1CoGfYTp9BapH.Mi6Lt.sVq");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$2.Dxe66GKqVmE1DmDhxLWuHVGYyF67tv0.LCnlFjSlNUwf9QNTAMu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$kuOdE1.zSFZaCAIE.nfwauvnG.XfOZR6/Tt1EYEM1CDM2L1fc2cVS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$kiv.nRzrs2fPgcl0beTmI.mREhGSgFnXiz3j6OvTzhjBwaRXmRId6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$SfhVF3rUd9GaHSPldtyU6uKKQIHUsZHhJKmMjwstK7b48w7nQRWrK");
        }
    }
}
