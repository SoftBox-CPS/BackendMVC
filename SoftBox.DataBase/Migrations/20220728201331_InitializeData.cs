using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftBox.DataBase.Migrations
{
    public partial class InitializeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "image_url", "name" },
                values: new object[,]
                {
                    { 1, "Аптека", null, "Аптека" },
                    { 2, "Книги", null, "Книги" },
                    { 3, "Одежда", null, "Одежда" },
                    { 4, "Обувь", null, "Обувь" },
                    { 5, "Техника", null, "Техника" },
                    { 6, "Мебель", null, "Мебель" },
                    { 7, "Спорт и отдых", null, "Спорт и отдых" },
                    { 8, "Хобби и творчество", null, "Хобби и творчество" },
                    { 9, "Для школы и офиса", null, "Для школы и офиса" },
                    { 10, "Для дома", null, "Для дома" },
                    { 11, "Зоотовары", null, "Зоотовары" },
                    { 12, "Юверирные украшения", null, "Юверирные украшени" },
                    { 13, "Оборудование", null, "Оборудование" },
                    { 14, "Детские товары", null, "Детские товары" },
                    { 15, "Дача и сад", null, "Дача и сад" },
                    { 16, "Строительство и ремонт", null, "Строительство и ремонт" },
                    { 17, "Красота и гигиена", null, "Красота и гигиена" },
                    { 18, "Электроника", null, "Электроника" }
                });

            migrationBuilder.InsertData(
                table: "room_user_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Владелец" },
                    { 2, "Пользователь" },
                    { 3, "Модератор" }
                });

            migrationBuilder.InsertData(
                table: "user_organization_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Организатор" },
                    { 2, "Директор" },
                    { 3, "Представитель" }
                });

            migrationBuilder.InsertData(
                table: "user_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" },
                    { 3, "moderator" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "room_user_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room_user_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room_user_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user_organization_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user_organization_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user_organization_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user_types",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
