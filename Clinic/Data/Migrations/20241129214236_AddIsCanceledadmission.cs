using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCanceledadmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Admissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsCancelled",
                value: false);

            migrationBuilder.UpdateData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsCancelled",
                value: false);

            migrationBuilder.UpdateData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsCancelled",
                value: false);

            migrationBuilder.UpdateData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsCancelled",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Admissions");
        }
    }
}
