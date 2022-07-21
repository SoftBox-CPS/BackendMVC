using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftBox.DataBase.Migrations
{
    public partial class RoomStatusAndExpirationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "expiration_date",
                table: "rooms",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "room_status_id",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "room_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_statuses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rooms_room_status_id",
                table: "rooms",
                column: "room_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_room_statuses_room_status_id",
                table: "rooms",
                column: "room_status_id",
                principalTable: "room_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_room_statuses_room_status_id",
                table: "rooms");

            migrationBuilder.DropTable(
                name: "room_statuses");

            migrationBuilder.DropIndex(
                name: "IX_rooms_room_status_id",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "expiration_date",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "room_status_id",
                table: "rooms");
        }
    }
}
