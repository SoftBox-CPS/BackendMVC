using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftBox.DataBase.Migrations
{
    public partial class FixNameDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date_start_offset",
                table: "user_organizations",
                newName: "start_date_time_offset");

            migrationBuilder.RenameColumn(
                name: "date_end_offset",
                table: "user_organizations",
                newName: "end_date_time_offset");

            migrationBuilder.RenameColumn(
                name: "DateTimeUTCMessage",
                table: "room_messages",
                newName: "create_date_time_offset");

            migrationBuilder.RenameColumn(
                name: "created_date_offset",
                table: "products",
                newName: "create_date_time_offset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "start_date_time_offset",
                table: "user_organizations",
                newName: "date_start_offset");

            migrationBuilder.RenameColumn(
                name: "end_date_time_offset",
                table: "user_organizations",
                newName: "date_end_offset");

            migrationBuilder.RenameColumn(
                name: "create_date_time_offset",
                table: "room_messages",
                newName: "DateTimeUTCMessage");

            migrationBuilder.RenameColumn(
                name: "create_date_time_offset",
                table: "products",
                newName: "created_date_offset");
        }
    }
}
