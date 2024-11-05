using System;
using ArgentoApp.Backend.Shared.DTOs.ImageDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;

namespace ArgentoApp.Backend.Shared.Helpers.Abstract;

public interface IImageHelper
{
    Task<ResponseDto<ImageDto>> UploadImageAsync(ImageCreateDto imageCreateDto);
    ResponseDto<NoContent> DeleteImage(ImageDeleteDto ımageDeleteDto);
}
