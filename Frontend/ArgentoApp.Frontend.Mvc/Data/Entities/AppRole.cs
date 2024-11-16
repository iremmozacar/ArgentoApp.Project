using System;
using Microsoft.AspNetCore.Identity;

namespace ArgentoApp.Frontend.Mvc.Data.Entities;

public class AppRole : IdentityRole
{
    public string Description { get; set; }
}
