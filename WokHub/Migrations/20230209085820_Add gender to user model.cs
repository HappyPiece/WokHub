using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WokHub.Migrations
{
    /// <inheritdoc />
    public partial class Addgendertousermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d885e87-7481-4606-80ed-5eda5a26254b"));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "birthDate" },
                values: new object[] { new Guid("42673abd-e47c-4a0c-b8e2-eeb7d625ae9e"), null, "aboba@gmail.com", null, null, "aboba123", null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42673abd-e47c-4a0c-b8e2-eeb7d625ae9e"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FullName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "birthDate" },
                values: new object[] { new Guid("7d885e87-7481-4606-80ed-5eda5a26254b"), null, "aboba@gmail.com", null, "aboba123", null, null, null, null });
        }
    }
}
