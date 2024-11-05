using ArgentoApp.Backend.Shared.DTOs.ImageDTOs;
using ArgentoApp.Backend.Shared.Helpers;
using ArgentoApp.Backend.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : CustomControllerBase
    {
        private readonly IImageHelper _imageHelper;

        public ImagesController(IImageHelper imageHelper)
        {
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ImageCreateDto ımageCreateDto)
        {
            var response = await _imageHelper.UploadImageAsync(ımageCreateDto);
            return CreateActionResult(response);
        }
        [HttpDelete]
        public IActionResult DeleteImage(ImageDeleteDto ımageDeleteDto)
        {
            var response = _imageHelper.DeleteImage(ımageDeleteDto);
            return CreateActionResult(response);

        }
    }
}
