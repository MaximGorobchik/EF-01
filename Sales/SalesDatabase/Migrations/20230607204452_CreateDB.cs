using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesDatabase.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    CreditCardNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, defaultValue: "No description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CreditCardNumber", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "6494-4939-1674-3708", "Graciela_Deckow64@hotmail.com", "Alberta" },
                    { 2, "6373-5546-2446-0046", "Douglas_Ziemann35@hotmail.com", "David" },
                    { 3, "6767-1243-9212-4646-886", "Micheal_Goyette21@hotmail.com", "Alexandra" },
                    { 4, "6771-8964-9753-3468", "Ernesto_Haley@yahoo.com", "Claudie" },
                    { 5, "3529-1938-2848-5010", "Rhett91@hotmail.com", "Kayli" },
                    { 6, "5393-9247-0571-4405", "Margot.Bins@hotmail.com", "Pat" },
                    { 7, "3761-049374-11417", "Garth.DAmore43@yahoo.com", "Thora" },
                    { 8, "6759-0420-6985-9827", "Lemuel_Hoppe64@gmail.com", "Isom" },
                    { 9, "3717-870457-56361", "Rigoberto2@gmail.com", "Giovani" },
                    { 10, "6384-7276-4760-4934", "Angel24@yahoo.com", "Guido" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Unbranded Metal Sausages", 1049m, 7m },
                    { 2, "Sleek Concrete Hat", 2348m, 2m },
                    { 3, "Generic Concrete Salad", 2800m, 9m },
                    { 4, "Sleek Wooden Chips", 2964m, 4m },
                    { 5, "Incredible Cotton Towels", 1081m, 2m },
                    { 6, "Refined Rubber Pants", 919m, 2m },
                    { 7, "Practical Metal Towels", 1175m, 8m },
                    { 8, "Rustic Soft Gloves", 445m, 1m },
                    { 9, "Rustic Fresh Shoes", 2429m, 6m },
                    { 10, "Tasty Soft Car", 1864m, 9m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreID", "Name" },
                values: new object[,]
                {
                    { 1, "Johns - Bauch" },
                    { 2, "Mraz - Bernier" },
                    { 3, "Abernathy - Legros" },
                    { 4, "Mills, Considine and Kessler" },
                    { 5, "Farrell - Ernser" },
                    { 6, "Ward - Brown" },
                    { 7, "Davis and Sons" },
                    { 8, "Bechtelar, Adams and Schneider" },
                    { 9, "Stoltenberg - Cronin" },
                    { 10, "Barrows, Ortiz and Stokes" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleID", "CustomerID", "Date", "ProductID", "StoreID" },
                values: new object[,]
                {
                    { 1, 9, new DateTime(2022, 9, 7, 23, 11, 49, 282, DateTimeKind.Local).AddTicks(3204), 1, 3 },
                    { 2, 4, new DateTime(2022, 10, 31, 4, 25, 13, 750, DateTimeKind.Local).AddTicks(5778), 10, 9 },
                    { 3, 4, new DateTime(2022, 9, 12, 9, 19, 53, 224, DateTimeKind.Local).AddTicks(7367), 10, 9 },
                    { 4, 8, new DateTime(2023, 1, 5, 21, 58, 1, 692, DateTimeKind.Local).AddTicks(4886), 7, 1 },
                    { 5, 4, new DateTime(2023, 2, 5, 7, 3, 21, 324, DateTimeKind.Local).AddTicks(7090), 4, 6 },
                    { 6, 3, new DateTime(2023, 4, 1, 4, 41, 42, 881, DateTimeKind.Local).AddTicks(6775), 1, 6 },
                    { 7, 6, new DateTime(2022, 6, 21, 14, 12, 45, 906, DateTimeKind.Local).AddTicks(5200), 6, 5 },
                    { 8, 1, new DateTime(2022, 11, 22, 6, 27, 2, 735, DateTimeKind.Local).AddTicks(7874), 3, 2 },
                    { 9, 2, new DateTime(2022, 10, 23, 18, 47, 39, 396, DateTimeKind.Local).AddTicks(872), 6, 10 },
                    { 10, 9, new DateTime(2023, 5, 6, 8, 47, 3, 968, DateTimeKind.Local).AddTicks(8621), 10, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerID",
                table: "Sales",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductID",
                table: "Sales",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StoreID",
                table: "Sales",
                column: "StoreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
