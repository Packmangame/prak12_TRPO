using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRPO.Migrations
{
    /// <inheritdoc />
    public partial class INS3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
