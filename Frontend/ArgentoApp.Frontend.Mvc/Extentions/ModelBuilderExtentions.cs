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
        List<AppRole> roles = [
            new() { Name="Super Admin", Description="Sistemdeki her türlü işi yapmaya yetkili rol", NormalizedName="SUPER ADMIN"},
            new() { Name="Admin", Description="Sistemdeki yönetimsel işleri yapmaya yetkili rol", NormalizedName="ADMIN"},
            new() { Name="Customer", Description="Müşterilerin rolü", NormalizedName="CUSTOMER"}
        ];
        modelBuilder.Entity<AppRole>().HasData(roles);
        #endregion

        #region Örnek Kullanıcı Bilgileri Tanımlanıyor
        List<AppUser> users = [
            new() { FirstName="Deniz", LastName="Çoban", Email="denizcoban@example.com", UserName="denizcoban", EmailConfirmed=true, NormalizedEmail="DENIZCOBAN@EXAMPLE.COM", NormalizedUserName="DENIZCOBAN"},

            new() { FirstName="Seden", LastName="Kaban", Email="sedenkaban@example.com", UserName="sedenkaban", EmailConfirmed=true, NormalizedEmail="SEDENKABAN@EXAMPLE.COM", NormalizedUserName="SEDENKABAN"},

            new() { FirstName="Kemal", LastName="Candan", Email="kemalcandan@example.com", UserName="kemalcandan", EmailConfirmed=true, NormalizedEmail="KEMALCANDAN@EXAMPLE.COM", NormalizedUserName="KEMALCANDAN"},

            new() { FirstName="Berfu", LastName="Keloğlan", Email="berfukeloglan@example.com", UserName="berfukeloglan", EmailConfirmed=true, NormalizedEmail="BERFUKELOGLAN@EXAMPLE.COM", NormalizedUserName="BERFUKELOGLAN"},

            new() { FirstName="Can", LastName="Tan", Email="cantan@example.com", UserName="cantan", EmailConfirmed=true, NormalizedEmail="CANTAN@EXAMPLE.COM", NormalizedUserName="CANTAN"},

            new() { FirstName="Müge", LastName="Por", Email="mugepor@example.com", UserName="mugepor", EmailConfirmed=true, NormalizedEmail="MUGEPOR@EXAMPLE.COM", NormalizedUserName="MUGEPOR"}
        ];
        modelBuilder.Entity<AppUser>().HasData(users);
        #endregion

        #region Rol Atama İşlemleri Yapılıyor
        List<IdentityUserRole<string>> identityUserRoles = [
            new IdentityUserRole<string>{ RoleId=roles[0].Id, UserId=users[0].Id},
            new IdentityUserRole<string>{ RoleId=roles[1].Id, UserId=users[1].Id},
            new IdentityUserRole<string>{ RoleId=roles[2].Id, UserId=users[2].Id},
            new IdentityUserRole<string>{ RoleId=roles[2].Id, UserId=users[3].Id},
            new IdentityUserRole<string>{ RoleId=roles[2].Id, UserId=users[4].Id},
            new IdentityUserRole<string>{ RoleId=roles[2].Id, UserId=users[5].Id},
            new IdentityUserRole<string>{ RoleId=roles[1].Id, UserId=users[2].Id}
        ];
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
