using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace midis.muchik.market.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(250)", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(250)", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(250)", nullable: false),
                    name = table.Column<string>(type: "varchar(250)", nullable: false),
                    sku = table.Column<string>(type: "varchar(12)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    category_id = table.Column<string>(type: "varchar(250)", nullable: false),
                    brand_id = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_brand",
                        column: x => x.brand_id,
                        principalTable: "brand",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_product_category",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_brand_id",
                table: "product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
