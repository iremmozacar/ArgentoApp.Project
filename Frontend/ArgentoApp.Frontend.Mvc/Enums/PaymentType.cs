using System;
using System.ComponentModel.DataAnnotations;

namespace ArgentoApp.Frontend.Mvc.Enums;


public enum PaymentType
{
    [Display(Name = "Kredi Kartı")]
    CreditCard = 0,
    [Display(Name = "Eft/Havale")]
    Eft = 1
}
