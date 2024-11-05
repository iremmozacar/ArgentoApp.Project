using System;

namespace ArgentoApp.Backend.Entity.Abstact;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public string Url { get; set; }


}
