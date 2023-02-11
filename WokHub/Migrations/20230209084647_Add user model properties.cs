using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WokHub.Migrations
{
    /// <inheritdoc />
    public partial class Addusermodelproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23f49f47-881f-49c9-88b8-d0ac2079193f"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "birthDate",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FullName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "birthDate" },
                values: new object[] { new Guid("7d885e87-7481-4606-80ed-5eda5a26254b"), null, "aboba@gmail.com", null, "aboba123", null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d885e87-7481-4606-80ed-5eda5a26254b"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[] { new Guid("23f49f47-881f-49c9-88b8-d0ac2079193f"), "aboba@gmail.com", "aboba123", null, null });
        }
    }
}
