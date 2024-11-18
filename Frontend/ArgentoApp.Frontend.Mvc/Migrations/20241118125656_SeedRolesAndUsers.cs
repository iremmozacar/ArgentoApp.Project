using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgentoApp.Frontend.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Roles
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "Description" },
                values: new object[,]
                {
                    { "1", "Super Admin", "SUPER ADMIN", "Sistemdeki her türlü işi yapmaya yetkili rol" },
                    { "2", "Admin", "ADMIN", "Sistemdeki yönetimsel işleri yapmaya yetkili rol" },
                    { "3", "Customer", "CUSTOMER", "Müşterilerin rolü" }
                }
            );

            // Seed a Super Admin User
            var adminUserId = "4"; // ID sabit bir değerle atanır, böylece ilişkisel ekleme yapılabilir.
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "FirstName", "LastName", "PhoneNumber", "PhoneNumberConfirmed" },
                values: new object[]
                {
                    adminUserId,
                    "denizcoban",
                    "DENIZCOBAN",
                    "denizcoban@example.com",
                    "DENIZCOBAN@EXAMPLE.COM",
                    true,
                    // "YourPassword123!"'ün bir hash değeri. Örnek hash eklenmiştir.
                    "AQAAAAEAACcQAAAAEDHcG3VYfXbAgsdpVD0yy+HnVW8Aa2zGZ5JhHJsyIrONxYdmvg==",
                    "some-random-security-stamp",
                    "Deniz",
                    "Çoban",
                    null, // Telefon numarası eklenmediği için NULL
                    false // PhoneNumberConfirmed varsayılan olarak FALSE
                }
            );

            // Assign Super Admin Role to the User
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[]
                {
                    adminUserId,
                    "1" // Super Admin rolü ile ilişkilendirilir.
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Seed işlemini geri almak için silme işlemleri
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4", "1" }
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValues: new object[] { "1", "2", "3" }
            );
        }
    }
}
