using System.ComponentModel.DataAnnotations;

namespace ArgentoApp.Backend.Shared.ComplexTypes;

public enum PaymentType
{
    [Display(Name = "Kredi Kartı")]
    CreditCard = 0,
    [Display(Name = "EFT/Havale")]
    EFT = 1
}
