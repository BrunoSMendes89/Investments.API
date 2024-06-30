using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investments.Api.Migrations
{
    /// <inheritdoc />
    public partial class TransacionAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersProducts");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "customers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "AccountBalance",
                table: "customers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "bankstatements",
                columns: table => new
                {
                    BankStatementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatementDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankstatements", x => x.BankStatementId);
                    table.ForeignKey(
                        name: "FK_bankstatements_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => new { x.CustomersCustomerId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CustomerProduct_customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    BankStatementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_transactions_bankstatements_BankStatementId",
                        column: x => x.BankStatementId,
                        principalTable: "bankstatements",
                        principalColumn: "BankStatementId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_bankstatements_CustomerId",
                table: "bankstatements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ProductsProductId",
                table: "CustomerProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_BankStatementId",
                table: "transactions",
                column: "BankStatementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "bankstatements");

            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "customers");

            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomersProducts",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersProducts", x => new { x.CustomersCustomerId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CustomersProducts_customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersProducts_products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersProducts_ProductsProductId",
                table: "CustomersProducts",
                column: "ProductsProductId");
        }
    }
}
