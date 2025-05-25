using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEventReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<string>(type: "TEXT", nullable: true),
                    ActivityType = table.Column<string>(type: "TEXT", nullable: true),
                    RegisteredCount = table.Column<int>(type: "INTEGER", nullable: false),
                    AttendanceCount = table.Column<int>(type: "INTEGER", nullable: false),
                    OccupancyRate = table.Column<double>(type: "REAL", nullable: false),
                    ResourceUsage = table.Column<string>(type: "TEXT", nullable: true),
                    ScheduleCompliance = table.Column<double>(type: "REAL", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventReports");
        }
    }
}
