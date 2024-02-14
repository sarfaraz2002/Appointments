using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointments.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Specialist",
                table: "Doctor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Doctor",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorId", "Name", "Phone", "Specialist" },
                values: new object[,]
                {
                    { 11, "Doctor1", "111-111-1111", "Specialty1" },
                    { 12, "Doctor2", "222-222-2222", "Specialty2" },
                    { 13, "Doctor3", "333-333-3333", "Specialty3" },
                    { 14, "Doctor4", "444-444-4444", "Specialty4" },
                    { 15, "Doctor5", "555-555-5555", "Specialty5" },
                    { 16, "Doctor6", "666-666-6666", "Specialty6" },
                    { 17, "Doctor7", "777-777-7777", "Specialty7" },
                    { 18, "Doctor8", "888-888-8888", "Specialty8" },
                    { 19, "Doctor9", "999-999-9999", "Specialty9" },
                    { 20, "Doctor10", "000-000-0000", "Specialty10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorId",
                keyValue: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Specialist",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
