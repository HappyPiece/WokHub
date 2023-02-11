using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WokHub.Migrations
{
    /// <inheritdoc />
    public partial class Renameusermodeldataannotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42673abd-e47c-4a0c-b8e2-eeb7d625ae9e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "birthDate" },
                values: new object[] { new Guid("8ffba3ab-b4dc-4fd9-af1c-4495ecb40bda"), null, "aboba@gmail.com", null, null, "aboba123", null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ffba3ab-b4dc-4fd9-af1c-4495ecb40bda"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "birthDate" },
                values: new object[] { new Guid("42673abd-e47c-4a0c-b8e2-eeb7d625ae9e"), null, "aboba@gmail.com", null, null, "aboba123", null, null, null, null });
        }
    }
}
