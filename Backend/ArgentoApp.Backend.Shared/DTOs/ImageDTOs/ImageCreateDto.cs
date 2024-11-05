using System;
using Microsoft.AspNetCore.Http;

namespace ArgentoApp.Backend.Shared.DTOs.ImageDTOs;

public class ImageCreateDto
{
    public IFormFile Image { get; set; }
    public string folderName { get; set; }

}
