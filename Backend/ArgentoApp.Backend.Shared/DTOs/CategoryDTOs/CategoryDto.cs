using System;

namespace ArgentoApp.Backend.Shared.DTOs.Categories;

public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public string Url { get; set; }
    public string Description { get; set; }

}

