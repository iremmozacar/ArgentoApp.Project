using System;

namespace ArgentoApp.Backend.Shared.DTOs;

public class CategoryUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public string Description { get; set; }
}
