using System.ComponentModel.DataAnnotations;

namespace ArgentoApp.Backend.Shared.ComplexTypes;

public enum OrderState
{
    [Display(Name = "Sipariş Alındı")]
    Received = 0,
    [Display(Name = "Sipariş Hazırlanıyor")]
    Preparing = 1,

    [Display(Name = "Kargoya verildi")]
    Send = 2,
    [Display(Name = "Teslim edildi")]
    Delivered = 3
}
