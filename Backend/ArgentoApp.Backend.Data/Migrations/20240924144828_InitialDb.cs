using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgentoApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelledOrderItems");

            migrationBuilder.DropTable(
                name: "CancelledOrders");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8480), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8490), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8500), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8500), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8500), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8510), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8510), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9520), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9530), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9540), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9540), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9550), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9560), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9570), new DateTime(2024, 9, 24, 17, 48, 28, 623, DateTimeKind.Local).AddTicks(9570) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "CancelledOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelledOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CancelledOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CancelledOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelledOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancelledOrderItems_CancelledOrders_CancelledOrderId",
                        column: x => x.CancelledOrderId,
                        principalTable: "CancelledOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancelledOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8900), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9870), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9870) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9880), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9880), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9900), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9910), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9910) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9910), new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9920) });

            migrationBuilder.CreateIndex(
                name: "IX_CancelledOrderItems_CancelledOrderId",
                table: "CancelledOrderItems",
                column: "CancelledOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CancelledOrderItems_ProductId",
                table: "CancelledOrderItems",
                column: "ProductId");
        }
    }
}
