using System;

namespace ArgentoApp.Backend.Entity.Concrete;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserName { get; set; }
}
