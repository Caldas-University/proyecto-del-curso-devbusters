using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEventIdToActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Events_Eventid",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Eventid",
                table: "Activities",
                newName: "eventId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_Eventid",
                table: "Activities",
                newName: "IX_Activities_eventId");

            migrationBuilder.AlterColumn<Guid>(
                name: "eventId",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Events_eventId",
                table: "Activities",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Events_eventId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "eventId",
                table: "Activities",
                newName: "Eventid");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_eventId",
                table: "Activities",
                newName: "IX_Activities_Eventid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Eventid",
                table: "Activities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Events_Eventid",
                table: "Activities",
                column: "Eventid",
                principalTable: "Events",
                principalColumn: "id");
        }
    }
}
