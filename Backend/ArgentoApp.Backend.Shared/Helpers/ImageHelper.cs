using System;
using ArgentoApp.Backend.Shared.DTOs.ImageDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;
using ArgentoApp.Backend.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Hosting;

namespace ArgentoApp.Backend.Shared.Helpers;

public class ImageHelper : IImageHelper
{
    private readonly string _imagesFolder;
    public ImageHelper(IWebHostEnvironment webHostEnvironment)
    {
        _imagesFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
    }

    private bool IsImageValid(string extension)
    {
        string[] correctExtensions = { ".png", ".jpeg", ".jpg" };
        bool result = correctExtensions.Contains(extension);
        return result;


    }
    public async Task<ResponseDto<ImageDto>> UploadImageAsync(ImageCreateDto imageCreateDto)
    {
        if (imageCreateDto.Image == null || imageCreateDto.Image.Length == 0)
        {
            return ResponseDto<ImageDto>.Fail("Bir hata oluştu!", 400);
        }
        var imageExtension = Path.GetExtension(imageCreateDto.Image.FileName);
        if (!IsImageValid(imageExtension))
        {
            return ResponseDto<ImageDto>.Fail("Geçersiz format!", 400);
        }
        var targetFolder = Path.Combine(_imagesFolder, imageCreateDto.folderName ?? "general");
        if (!Directory.Exists(targetFolder))
        {
            Directory.CreateDirectory(targetFolder);
        }
        var fileName = $"{Guid.NewGuid()}{imageExtension}";
        var fullPath = Path.Combine(targetFolder, fileName);
        await using var stream = new FileStream(fullPath, FileMode.Create);
        imageCreateDto.Image.CopyTo(stream);
        ImageDto imageDto = new()
        {
            Url = Path.Combine("images", imageCreateDto.folderName ?? "General", fileName),
            Name = fileName
        };
        return ResponseDto<ImageDto>.Success(imageDto, 201);
    }

    public ResponseDto<NoContent> DeleteImage(ImageDeleteDto imageDeleteDto)
    {
        var fullPath = Path.Combine(_imagesFolder, imageDeleteDto.FolderName, imageDeleteDto.FileName);
        if (!File.Exists(fullPath))
        {
            return ResponseDto<NoContent>.Fail("Böyle bir resim bulunamadı!", 404);
        }
        File.Delete(fullPath);
        return ResponseDto<NoContent>.Success(200);
    }
}
