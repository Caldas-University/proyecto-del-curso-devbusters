using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    startDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    duration = table.Column<float>(type: "REAL", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: false),
                    Eventid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.id);
                    table.ForeignKey(
                        name: "FK_Activity_Events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "Events",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    generatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    filters = table.Column<string>(type: "TEXT", nullable: false),
                    Eventid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                    table.ForeignKey(
                        name: "FK_Report_Events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "Events",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Eventid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "Events",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Eventid",
                table: "Activity",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Report_Eventid",
                table: "Report",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_User_Eventid",
                table: "User",
                column: "Eventid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
