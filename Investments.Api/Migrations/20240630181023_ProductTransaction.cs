using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investments.Api.Migrations
{
    /// <inheritdoc />
    public partial class ProductTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_ProductId",
                table: "transactions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_products_ProductId",
                table: "transactions",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_products_ProductId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_ProductId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "transactions");
        }
    }
}
