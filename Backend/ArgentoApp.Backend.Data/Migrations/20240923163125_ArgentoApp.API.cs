using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArgentoApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArgentoAppAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancelledOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelledOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IsCancel = table.Column<bool>(type: "INTEGER", nullable: false),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancelledOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CancelledOrderId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quentity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[] { 1, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(7270), "1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8900), "Kök çakra ile uyumlu taşlar burada. Kırmızı renk ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8900), "1. Kök Çakra (Muladhara Çakra)", "Kök" },
                    { 2, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), "Sakral çakra ile uyumlu taşlar burada. Turuncu renk ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), "2.Sakral Çakra (Svadhistana Çakra)", "Sakral" },
                    { 3, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), "Solar Plexus çakra ile uyumlu taşlar burada. Sarı renk ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), "3. Solar Pleksus Çakra(Manipura Çakra)", "SolarPlexus" },
                    { 4, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), "Kalp çakrası ile uyumlu taşlar burada. Yeşil renk ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8910), "4.Kalp Çakrası (Anahata Çakra)", "Kalp" },
                    { 5, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), "Boğaz çakrası ile uyumlu taşlar burada. Mavi renk ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), "5.Boğaz Çakrası (Vishuddha Çakra) ", "Boğaz" },
                    { 6, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), "3.Göz çakrası ile uyumlu taşlar burada. İndigo mavi ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), "6.Üçüncü Göz Çakrası (Ajna Çakra)", "3.Göz" },
                    { 7, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8920), "Taç çakra ile uyumlu taşlar burada. Menekşe rengi ile ifade edilir.", true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(8930), "7.Taç Çakra (Sahasrara Çakra)", "Taç" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9870), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9870), "Kırmızı Jasper", 100m, "Kırmızı Jasper", "Jasper" },
                    { 2, 2, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9880), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9880), "Turuncu Kalsit", 200m, "Turuncu Kalsit", "Kalsit" },
                    { 3, 3, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9880), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9890), "Kaplan Gözü ", 300m, "Kaplan Gözü", "KaplanGozu" },
                    { 4, 4, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9890), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9890), "Moldavit", 400m, "Moldavit", "Moldavit" },
                    { 5, 5, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9900), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9900), "Larimar", 500m, "Larimar", "Larimar" },
                    { 6, 3, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9910), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9910), "Sodalit", 600m, "Sodalit", "Sodalit" },
                    { 7, 7, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9910), "", true, true, new DateTime(2024, 9, 23, 19, 31, 25, 9, DateTimeKind.Local).AddTicks(9920), "Kristal Kuvars", 700m, "Kristal Kuvars", "KristalKuvars" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancelledOrderItems_CancelledOrderId",
                table: "CancelledOrderItems",
                column: "CancelledOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CancelledOrderItems_ProductId",
                table: "CancelledOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelledOrderItems");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "CancelledOrders");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
