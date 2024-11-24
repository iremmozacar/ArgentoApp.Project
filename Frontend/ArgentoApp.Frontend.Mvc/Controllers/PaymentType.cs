using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Frontend.Mvc.Controllers
{
    public enum PaymentType
    {
        [Display(Name = "Kredi Kartı")]
        CreditCard = 0,
        [Display(Name = "Eft/Havale")]
        Eft = 1
    }
}
