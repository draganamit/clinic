using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Muško" },
                    { 2L, "Žensko" },
                    { 3L, "Ostalo" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Specijalista" },
                    { 2L, "Specijalizant" },
                    { 3L, "Medicinska sestra" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "DateOfBirth", "DoctorCode", "FirstName", "GenderId", "JMBG", "LastName", "PhoneNumber", "TitleId" },
                values: new object[,]
                {
                    { 1L, "Sarajevo, BiH", new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ap1", "Aleksandar", 1L, "0101993752010", "Petrović", "+387 61 234 567", 1L },
                    { 2L, "Sarajevo, BiH", new DateTime(1975, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "im2", "Ivana", 1L, "0202991234123", "Marić", "+387 61 432 123", 3L },
                    { 3L, "Sarajevo, BiH", new DateTime(1982, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sb3", "Selma", 2L, "0202991234567", "Begović", "+387 62 345 678", 2L }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "GenderId", "JMBG", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "Sarajevo, BiH", new DateTime(1985, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko", 1L, "0404993456789", "Jurić", "+387 66 234 567" },
                    { 2L, "Sarajevo, BiH", new DateTime(1992, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jelena", 2L, "0606995678901", "Nikolić", "+381 64 678 901" }
                });

            migrationBuilder.InsertData(
                table: "Admissions",
                columns: new[] { "Id", "AdmissionDate", "DoctorId", "IsEmergency", "PatientId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, true, 1L },
                    { 2L, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, false, 2L },
                    { 3L, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, true, 1L },
                    { 4L, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, false, 2L }
                });

            migrationBuilder.InsertData(
                table: "MedicalReports",
                columns: new[] { "Id", "AdmissionId", "CreatedAt", "ReportDescription" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacijent je primljen u hitnoj pomoći zbog povrede na radu." },
                    { 2L, 2L, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacijentkinja je primljena zbog respiratornih problema." },
                    { 3L, 3L, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacijentkinja je primljena u hitnoj pomoći zbog akutnih bolova u stomaku." },
                    { 4L, 4L, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pacijent je primljen zbog problema sa visokim krvnim pritiskom. Preporučena terapija i kontrola." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "MedicalReports",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MedicalReports",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "MedicalReports",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "MedicalReports",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Admissions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
