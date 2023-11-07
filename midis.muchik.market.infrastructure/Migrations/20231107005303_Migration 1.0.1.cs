using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace midis.muchik.market.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "order_detail",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order_detail",
                newName: "order_id");

            migrationBuilder.AlterColumn<string>(
                name: "product_id",
                table: "order_detail",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "order_detail",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "order_detail",
                newName: "OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "order_detail",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");
        }
    }
}
