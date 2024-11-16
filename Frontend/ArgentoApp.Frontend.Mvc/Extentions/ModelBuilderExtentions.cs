using System;
using ArgentoApp.Frontend.Mvc.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArgentoApp.Frontend.Mvc.Extentions;

public static class ModelBuilderExtensions
{
    public static void SeedIdentityData(this ModelBuilder modelBuilder)
    {
        #region Örnek Rol Bilgileri Tanımlanıyor
        List<AppRole> roles = new List<AppRole>
        {
            new AppRole { Id = "1", Name = "Super Admin", Description = "Sistemdeki her türlü işi yapmaya yetkili rol", NormalizedName = "SUPER ADMIN" },
            new AppRole { Id = "2", Name = "Admin", Description = "Sistemdeki yönetimsel işleri yapmaya yetkili rol", NormalizedName = "ADMIN" },
            new AppRole { Id = "3", Name = "Customer", Description = "Müşterilerin rolü", NormalizedName = "CUSTOMER" }
        };
        modelBuilder.Entity<AppRole>().HasData(roles);
        #endregion

        #region Örnek Kullanıcı Bilgileri Tanımlanıyor
        List<AppUser> users = new List<AppUser>
        {
            new AppUser { Id = "1", FirstName = "Deniz", LastName = "Çoban", Email = "denizcoban@example.com", UserName = "denizcoban", EmailConfirmed = true, NormalizedEmail = "DENIZCOBAN@EXAMPLE.COM", NormalizedUserName = "DENIZCOBAN" },
            new AppUser { Id = "2", FirstName = "Seden", LastName = "Kaban", Email = "sedenkaban@example.com", UserName = "sedenkaban", EmailConfirmed = true, NormalizedEmail = "SEDENKABAN@EXAMPLE.COM", NormalizedUserName = "SEDENKABAN" },
            new AppUser { Id = "3", FirstName = "Kemal", LastName = "Candan", Email = "kemalcandan@example.com", UserName = "kemalcandan", EmailConfirmed = true, NormalizedEmail = "KEMALCANDAN@EXAMPLE.COM", NormalizedUserName = "KEMALCANDAN" },
            new AppUser { Id = "4", FirstName = "Berfu", LastName = "Keloğlan", Email = "berfukeloglan@example.com", UserName = "berfukeloglan", EmailConfirmed = true, NormalizedEmail = "BERFUKELOGLAN@EXAMPLE.COM", NormalizedUserName = "BERFUKELOGLAN" },
            new AppUser { Id = "5", FirstName = "Can", LastName = "Tan", Email = "cantan@example.com", UserName = "cantan", EmailConfirmed = true, NormalizedEmail = "CANTAN@EXAMPLE.COM", NormalizedUserName = "CANTAN" },
            new AppUser { Id = "6", FirstName = "Müge", LastName = "Por", Email = "mugepor@example.com", UserName = "mugepor", EmailConfirmed = true, NormalizedEmail = "MUGEPOR@EXAMPLE.COM", NormalizedUserName = "MUGEPOR" }
        };
        modelBuilder.Entity<AppUser>().HasData(users);
        #endregion

        #region Rol Atama İşlemleri Yapılıyor
        List<IdentityUserRole<string>> identityUserRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string> { RoleId = "1", UserId = "1" }, // Super Admin -> Deniz
            new IdentityUserRole<string> { RoleId = "2", UserId = "2" }, // Admin -> Seden
            new IdentityUserRole<string> { RoleId = "3", UserId = "3" }, // Customer -> Kemal
            new IdentityUserRole<string> { RoleId = "3", UserId = "4" }, // Customer -> Berfu
            new IdentityUserRole<string> { RoleId = "3", UserId = "5" }, // Customer -> Can
            new IdentityUserRole<string> { RoleId = "3", UserId = "6" }, // Customer -> Müge
            new IdentityUserRole<string> { RoleId = "2", UserId = "3" }  // Admin -> Kemal (Özel atama)
        };
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoles);
        #endregion

        #region Şifre Atama İşlemleri Yapılıyor
        var passwordHasher = new PasswordHasher<AppUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
        users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");
        users[4].PasswordHash = passwordHasher.HashPassword(users[4], "Qwe123.");
        users[5].PasswordHash = passwordHasher.HashPassword(users[5], "Qwe123.");
        #endregion
    }
}