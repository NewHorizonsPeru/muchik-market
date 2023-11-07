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
                name: "order",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(250)", nullable: false),
                    correlative = table.Column<string>(type: "varchar(25)", nullable: false),
                    customer_id = table.Column<string>(type: "varchar(250)", nullable: false),
                    state = table.Column<short>(type: "smallint", nullable: false),
                    total = table.Column<decimal>(type: "decimal", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "varchar(250)", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<short>(type: "smallint", nullable: false),
                    price = table.Column<decimal>(type: "decimal", nullable: false),
                    total = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_order_orderdetail",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "id");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
