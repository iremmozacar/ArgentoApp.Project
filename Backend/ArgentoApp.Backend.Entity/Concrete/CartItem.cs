using ArgentoApp.Backend.Entity.Concrete.Abstact;

namespace ArgentoApp.Backend.Entity.Concrete;

public class CartItem
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    public int Quentity { get; set; }
}