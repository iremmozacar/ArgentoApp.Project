using System;
using ArgentoApp.Backend.Shared.ComplexTypes;

namespace ArgentoApp.Backend.Entity.Concrete;

public class Order
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Adress { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsCancel { get; set; }
    public PaymentType PaymentType { get; set; }
    public OrderState OrderState { get; set; }
    public List<OrderItem> OrderItems { get; set; }

}
