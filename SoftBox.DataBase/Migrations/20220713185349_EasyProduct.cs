using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftBox.DataBase.Migrations
{
    public partial class EasyProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_organization_products_organization_product_id",
                table: "rooms");

            migrationBuilder.DropTable(
                name: "organization_products");

            migrationBuilder.RenameColumn(
                name: "organization_product_id",
                table: "rooms",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_organization_product_id",
                table: "rooms",
                newName: "IX_rooms_product_id");

            migrationBuilder.AddColumn<Guid>(
                name: "organization_id",
                table: "products",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_products_organization_id",
                table: "products",
                column: "organization_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_organizations_organization_id",
                table: "products",
                column: "organization_id",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_products_product_id",
                table: "rooms",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_organizations_organization_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_products_product_id",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_products_organization_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "organization_id",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "rooms",
                newName: "organization_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_product_id",
                table: "rooms",
                newName: "IX_rooms_organization_product_id");

            migrationBuilder.CreateTable(
                name: "organization_products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    organization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_organization_products_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_organization_products_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organization_products_organization_id",
                table: "organization_products",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "IX_organization_products_product_id_organization_id",
                table: "organization_products",
                columns: new[] { "product_id", "organization_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_organization_products_organization_product_id",
                table: "rooms",
                column: "organization_product_id",
                principalTable: "organization_products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
