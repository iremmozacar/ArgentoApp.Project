using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgentoApp.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4370), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4380), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4380), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4390), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4390), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4390), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4400), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5300), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5300) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5310), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5320), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5320) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5320), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5330), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5340), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5350), new DateTime(2024, 11, 18, 17, 33, 26, 188, DateTimeKind.Local).AddTicks(5350) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
