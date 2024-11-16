using System;
using Microsoft.AspNetCore.Identity;

namespace ArgentoApp.Frontend.Mvc.Data.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
