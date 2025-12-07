using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRPO.Migrations
{
    /// <inheritdoc />
    public partial class inc3tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "interestGroups",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interestGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userInterestGroups",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    InterestGroupID = table.Column<long>(type: "bigint", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userInterestGroups", x => new { x.UserId, x.InterestGroupID });
                    table.ForeignKey(
                        name: "FK_userInterestGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userInterestGroups_interestGroups_InterestGroupID",
                        column: x => x.InterestGroupID,
                        principalTable: "interestGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_interestGroups_Title",
                table: "interestGroups",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userInterestGroups_InterestGroupID",
                table: "userInterestGroups",
                column: "InterestGroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userInterestGroups");

            migrationBuilder.DropTable(
                name: "interestGroups");
        }
    }
}
