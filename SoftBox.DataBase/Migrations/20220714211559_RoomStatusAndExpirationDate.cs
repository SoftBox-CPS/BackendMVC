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
                name: "room_status",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "room_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_status", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rooms_room_status",
                table: "rooms",
                column: "room_status");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_room_status_room_status",
                table: "rooms",
                column: "room_status",
                principalTable: "room_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_room_status_room_status",
                table: "rooms");

            migrationBuilder.DropTable(
                name: "room_status");

            migrationBuilder.DropIndex(
                name: "IX_rooms_room_status",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "expiration_date",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "room_status",
                table: "rooms");
        }
    }
}
