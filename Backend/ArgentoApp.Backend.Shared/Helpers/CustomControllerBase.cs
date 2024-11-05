using System;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ArgentoApp.Backend.Shared.Helpers;

public class CustomControllerBase : ControllerBase
{
    public static IActionResult CreateActionResult<T>(ResponseDto<T> responseDto)
    {
        return new ObjectResult(responseDto)
        {
            StatusCode = responseDto.StatusCode
        };
    }
}
