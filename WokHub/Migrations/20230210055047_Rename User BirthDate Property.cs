using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WokHub.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserBirthDateProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ffba3ab-b4dc-4fd9-af1c-4495ecb40bda"));

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[] { new Guid("73095614-cd16-4e7d-92ed-33b99e528623"), null, null, "aboba@gmail.com", null, null, "aboba123", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("73095614-cd16-4e7d-92ed-33b99e528623"));

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Users",
                newName: "birthDate");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "birthDate" },
                values: new object[] { new Guid("8ffba3ab-b4dc-4fd9-af1c-4495ecb40bda"), null, "aboba@gmail.com", null, null, "aboba123", null, null, null, null });
        }
    }
}
