using System;
using ArgentoApp.Frontend.Mvc.Data.Entities;
using ArgentoApp.Frontend.Mvc.Extentions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ArgentoApp.Frontend.Mvc.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.SeedIdentityData();
        base.OnModelCreating(builder);
    }
}
